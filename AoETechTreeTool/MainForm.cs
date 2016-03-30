using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenieLibrary;
using GenieLibrary.DataElements;

namespace AoETechTreeTool
{
	public partial class MainForm : Form
	{
		#region Constants

		/// <summary>
		/// The age image font.
		/// </summary>
		Font AGE_FONT = new Font("Cambria", 10, FontStyle.Bold);

		#endregion

		#region Variables

		/// <summary>
		/// The edited DAT file.
		/// </summary>
		private GenieLibrary.GenieFile _datFile = null;

		/// <summary>
		/// The language DLL handles.
		/// </summary>
		private GenieLibrary.LanguageFileWrapper _langDllWrapper = null;

		/// <summary>
		/// Specifies if currently an updating process is active. This suppresses various change/edit events.
		/// </summary>
		private bool _updating = false;

		/// <summary>
		/// The currently selected element.
		/// </summary>
		private TechTreeNew.TechTreeElement _selectedElement = null;

		#endregion

		#region Functions

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			// Load controls
			InitializeComponent();

			// Prepare tree view image list
			_treeView.ImageList = new ImageList();

			// Calculate image text size using a dummy object with the widest text (TextRenderer.MeasureText yields wrong results)
			using(Bitmap b = new Bitmap(1, 1))
			using(Graphics g = Graphics.FromImage(b))
				_treeView.ImageList.ImageSize = g.MeasureString("VII", AGE_FONT).ToSize();

			// Prepare civ list
			_civsList.ValueMember = "Key";
			_civsList.DisplayMember = "Value";

			// Prepare requirements view
			_requirementsViewTypeColumn.Items.Add("Unit");
			_requirementsViewTypeColumn.Items.Add("Building");
			_requirementsViewTypeColumn.Items.Add("Research");
		}

		/// <summary>
		/// Rebuilds the tree in the tree view from the DAT data.
		/// </summary>
		private void RefillTreeView()
		{
			// Prevent annyoing errors
			if(_datFile == null)
				return;

			// Initialize structures
			if(!_datFile.NewTechTree || _datFile.TechTreeNew == null)
			{
				// Set variables
				_datFile.NewTechTree = true;
				_datFile.TechTreeNew = new TechTreeNew() { ParentElements = new List<TechTreeNew.TechTreeElement>() };
			}

			// Run recursively through elements and create nodes
			Func<TechTreeNew.TechTreeElement, TreeNode> recursiveTreeViewFill = null;
			recursiveTreeViewFill = (element) =>
			  {
				  // Create age image
				  EnsureAgeImageExists(element.Age);

				  // Create node
				  TreeNode elementNode = new TreeNode();
				  elementNode.Tag = element;

				  // Update node display
				  UpdateNodeDisplay(elementNode);

				  // Run through children
				  foreach(var currChild in element.Children)
					  elementNode.Nodes.Add(recursiveTreeViewFill(currChild));
				  return elementNode;
			  };

			// Catch errors
			try
			{
				// Run recursion starting at root elements
				_treeView.SuspendLayout();
				_treeView.Nodes.Clear();
				foreach(var currChild in _datFile.TechTreeNew.ParentElements)
					_treeView.Nodes.Add(recursiveTreeViewFill(currChild));
				_treeView.ExpandAll();
				_treeView.ResumeLayout();
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error rendering tree data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		/// <summary>
		/// Builds the tree structure out of the tree view.
		/// </summary>
		private void BuildTechTreeStructure()
		{
			// Reset tree structure
			_datFile.TechTreeNew = new TechTreeNew() { ParentElements = new List<TechTreeNew.TechTreeElement>() };

			// Traverse tree view recursively
			Func<TreeNode, TechTreeNew.TechTreeElement> recursiveTreeViewTraversal = null;
			recursiveTreeViewTraversal = (node) =>
			{
				// Create element
				TechTreeNew.TechTreeElement nodeElement = (TechTreeNew.TechTreeElement)node.Tag;
				TechTreeNew.TechTreeElement newElement = new TechTreeNew.TechTreeElement()
				{
					Age = nodeElement.Age,
					Children = new List<TechTreeNew.TechTreeElement>(),
					DisableCivs = new List<byte>(nodeElement.DisableCivs),
					ElementObjectID = nodeElement.ElementObjectID,
					ElementType = nodeElement.ElementType,
					RenderMode = nodeElement.RenderMode,
					RequiredElements = new List<Tuple<TechTreeNew.TechTreeElement.ItemType, short>>(nodeElement.RequiredElements)
				};

				// Run through children
				foreach(TreeNode currChild in node.Nodes)
					newElement.Children.Add(recursiveTreeViewTraversal(currChild));
				return newElement;
			};

			// Run traversal starting at root elements
			foreach(TreeNode currChild in _treeView.Nodes)
				_datFile.TechTreeNew.ParentElements.Add(recursiveTreeViewTraversal(currChild));
		}

		/// <summary>
		/// Returns the name of the given tech tree element.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		private string GetElementName(TechTreeNew.TechTreeElement element)
		{
			// Call overload
			return GetElementName(element.ElementType, element.ElementObjectID);
		}

		/// <summary>
		/// Returns the name of the given tech tree element specified by its type and ID.
		/// </summary>
		/// <param name="elementType">The element type.</param>
		/// <param name="elementId">The element ID.</param>
		/// <returns></returns>
		private string GetElementName(TechTreeNew.TechTreeElement.ItemType elementType, short elementId)
		{
			// Switch by type
			if(elementType == TechTreeNew.TechTreeElement.ItemType.Research)
			{
				// Check for existence
				if(_datFile.Researches.Count <= elementId || elementId < 0)
					return "INVALID ID";
				string result = _langDllWrapper.GetString(_datFile.Researches[elementId].LanguageDLLName1);
				if(result == "")
					return _datFile.Researches[elementId].Name.TrimEnd('\0');
				return result;
			}
			else
			{
				// Check for existence
				if(!_datFile.Civs[0].Units.ContainsKey(elementId))
					return "INVALID ID";
				string result = _langDllWrapper.GetString(_datFile.Civs[0].Units[elementId].LanguageDLLName);
				if(result == "")
					return _datFile.Civs[0].Units[elementId].Name1.TrimEnd('\0');
				return result;
			}
		}

		/// <summary>
		/// Updates the display of the specified tree view node (text and age).
		/// </summary>
		/// <param name="node">The node to be updated.</param>
		private void UpdateNodeDisplay(TreeNode node)
		{
			// Valid?
			if(node == null)
				return;

			// Check whether there are requirements
			TechTreeNew.TechTreeElement element = (TechTreeNew.TechTreeElement)node.Tag;
			string nodeText = GetElementName(element);
			if(element.RequiredElements.Count > 0)
			{
				// Add requirements
				nodeText += " [";
				foreach(var req in element.RequiredElements)
					nodeText += GetElementName(req.Item1, req.Item2) + ", ";
				nodeText = nodeText.Remove(nodeText.Length - 2);
				nodeText += "]";
			}

			// Update node text
			node.Text = nodeText;

			// Set image
			EnsureAgeImageExists(element.Age);
			node.ImageIndex = element.Age;
			node.SelectedImageIndex = element.Age;
		}

		/// <summary>
		/// Creates the age images up to the specified ages, and inserts them into the image list.
		/// </summary>
		/// <param name="age">The maximum age.</param>
		private void EnsureAgeImageExists(int age)
		{
			// Get maximum image
			if(age < _treeView.ImageList.Images.Count)
				return; // Exists!

			// Create images from lastAge+1 to given one
			for(int i = _treeView.ImageList.Images.Count; i <= age; ++i)
			{
				// Get roman literal
				string roman;
				switch(i)
				{
					case 0: roman = "I"; break;
					case 1: roman = "II"; break;
					case 2: roman = "III"; break;
					case 3: roman = "IV"; break;
					case 4: roman = "V"; break;
					case 5: roman = "VI"; break;
					case 6: roman = "VII"; break;
					default: roman = "..."; break;
				}

				// Create bitmap
				Bitmap newImage = new Bitmap(_treeView.ImageList.ImageSize.Width, _treeView.ImageList.ImageSize.Height);
				using(Graphics newImageG = Graphics.FromImage(newImage))
				{
					// Draw onto image
					newImageG.Clear(Color.White);
					newImageG.DrawString(roman, AGE_FONT, Brushes.Black, 0, 0);
				}

				// Save bitmap
				_treeView.ImageList.Images.Add(newImage);
			}
		}

		#endregion

		#region Event handlers

		private void _loadDataButton_Click(object sender, EventArgs e)
		{
			// Show DAT open dialog
			if(_openDatFileDialog.ShowDialog() != DialogResult.OK)
				return;

			// Try open DAT file
			try
			{
				// Open
				IORAMHelper.RAMBuffer compressedFile = new IORAMHelper.RAMBuffer(_openDatFileDialog.FileName);
				_datFile = new GenieFile(GenieFile.DecompressData(compressedFile));
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error loading DAT file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Show language DLL open dialog
			if(_openLangDllDialog.ShowDialog() != DialogResult.OK)
				return;

			// Try load DLL files
			try
			{
				// Open
				_langDllWrapper = new LanguageFileWrapper(_openLangDllDialog.FileNames);
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error loading DLL files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Enable other controls
			_saveDataButton.Enabled = true;
			_exportTreeButton.Enabled = true;
			_importTreeButton.Enabled = true;
			_treeGroupBox.Enabled = true;
			_editPanel.Enabled = false;
			_entryNewButton.Enabled = true;

			// Update tree view
			RefillTreeView();

			// Fill civ list box
			_civsList.Items.Clear();
			for(byte i = 1; i < _datFile.Civs.Count; ++i)
				_civsList.Items.Add(new KeyValuePair<byte, string>(i, _datFile.Civs[i].Name.Trim()));
		}

		private void _saveDataButton_Click(object sender, EventArgs e)
		{
			// Show save dialog
			if(_saveDatFileDialog.ShowDialog() != DialogResult.OK)
				return;

			// Build tech tree structure
			BuildTechTreeStructure();

			// Save file
			try
			{
				// Save
				IORAMHelper.RAMBuffer uncompressedFile = new IORAMHelper.RAMBuffer();
				_datFile.WriteData(uncompressedFile);
				GenieFile.CompressData(uncompressedFile).Save(_saveDatFileDialog.FileName);
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error saving DAT file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void _exportTreeButton_Click(object sender, EventArgs e)
		{
			// Show save dialog
			if(_saveTechTreeDialog.ShowDialog() != DialogResult.OK)
				return;

			// Build tech tree structure
			BuildTechTreeStructure();

			// Save tree
			try
			{
				// Write into buffer
				IORAMHelper.RAMBuffer buffer = new IORAMHelper.RAMBuffer();
				_datFile.TechTreeNew.WriteData(buffer);

				// Save buffer
				buffer.Save(_saveTechTreeDialog.FileName);
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error exporting tech tree file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void _importTreeButton_Click(object sender, EventArgs e)
		{
			// Show open dialog
			if(_openTechTreeDialog.ShowDialog() != DialogResult.OK)
				return;

			// Load data and update tree view
			try
			{
				// Load data from file
				IORAMHelper.RAMBuffer buffer = new IORAMHelper.RAMBuffer(_openTechTreeDialog.FileName);
				_datFile.TechTreeNew = new TechTreeNew();
				_datFile.TechTreeNew.ReadData(buffer);

				// Disable edit panel
				_editPanel.Enabled = false;

				// Update view
				RefillTreeView();
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error importing tech tree file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void _treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			// Is no element selected? => Disable edit panel
			if(e.Node == null)
			{
				// No selection
				_editPanel.Enabled = false;
				_selectedElement = null;
				return;
			}

			// Element selected => Update edit panel
			_updating = true;
			_editPanel.Enabled = true;

			// Get element
			_selectedElement = (TechTreeNew.TechTreeElement)e.Node.Tag;

			// Update controls
			if(_selectedElement.ElementType == TechTreeNew.TechTreeElement.ItemType.Creatable)
				_typeUnitButton.Checked = true;
			else if(_selectedElement.ElementType == TechTreeNew.TechTreeElement.ItemType.Building)
				_typeBuildingButton.Checked = true;
			else if(_selectedElement.ElementType == TechTreeNew.TechTreeElement.ItemType.Research)
				_typeResearchButton.Checked = true;
			_idField.Value = _selectedElement.ElementObjectID;
			_ageField.Minimum = (e.Node.Parent != null ? ((TechTreeNew.TechTreeElement)e.Node.Parent.Tag).Age + 1 : 1);
			_ageField.Value = _selectedElement.Age + 1;
			if(_selectedElement.RenderMode == TechTreeNew.TechTreeElement.ItemRenderMode.Standard)
				_renderModeStandardButton.Checked = true;
			else if(_selectedElement.RenderMode == TechTreeNew.TechTreeElement.ItemRenderMode.HideIfDisabled)
				_renderModeHideButton.Checked = true;
			_requirementsView.Rows.Clear();
			foreach(var req in _selectedElement.RequiredElements)
				if(req.Item1 == TechTreeNew.TechTreeElement.ItemType.Building)
					_requirementsView.Rows.Add("Building", req.Item2.ToString());
				else if(req.Item1 == TechTreeNew.TechTreeElement.ItemType.Creatable)
					_requirementsView.Rows.Add("Unit", req.Item2.ToString());
				else
					_requirementsView.Rows.Add("Research", req.Item2.ToString());

			// Update civs
			for(int i = 0; i < _civsList.Items.Count; ++i)
				_civsList.SetItemChecked(i, !_selectedElement.DisableCivs.Contains(((KeyValuePair<byte, string>)_civsList.Items[i]).Key));

			// Ready
			_updating = false;
		}

		private void _entryNewButton_Click(object sender, EventArgs e)
		{
			// Create new element
			TechTreeNew.TechTreeElement newElement = new TechTreeNew.TechTreeElement()
			{
				Age = 0,
				Children = new List<TechTreeNew.TechTreeElement>(),
				DisableCivs = new List<byte>(),
				ElementObjectID = 0,
				ElementType = TechTreeNew.TechTreeElement.ItemType.Creatable,
				RenderMode = TechTreeNew.TechTreeElement.ItemRenderMode.Standard,
				RequiredElements = new List<Tuple<TechTreeNew.TechTreeElement.ItemType, short>>()
			};

			// Create node
			TreeNode newNode = new TreeNode(GetElementName(newElement));
			newNode.Tag = newElement;

			// Node selected?
			if(_treeView.SelectedNode == null || ModifierKeys.HasFlag(Keys.Shift))
			{
				// New parent element
				_treeView.Nodes.Add(newNode);
			}
			else
			{
				// Set parent and update age
				newElement.Age = ((TechTreeNew.TechTreeElement)_treeView.SelectedNode.Tag).Age;
				newNode.ImageIndex = newElement.Age;
				newNode.SelectedImageIndex = newElement.Age;
				_treeView.SelectedNode.Nodes.Add(newNode);
			}
			_treeView.Select();
		}

		private void _entryDeleteButton_Click(object sender, EventArgs e)
		{
			// Is a node selected?
			TreeNode selNode = _treeView.SelectedNode;
			if(selNode == null)
				return;

			// Ask
			if(MessageBox.Show("Really delete this node and all its children?", "Delete node", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				// Delete node
				if(selNode.Parent == null)
				{
					// Select next or previous node
					if(selNode.NextNode != null)
						_treeView.SelectedNode = selNode.NextNode;
					else if(selNode.PrevNode != null)
						_treeView.SelectedNode = selNode.PrevNode;
					else
						_treeView.SelectedNode = null;

					// Delete node
					_treeView.Nodes.Remove(selNode);
				}
				else
				{
					// Select next, previous or parent node
					if(selNode.NextNode != null)
						_treeView.SelectedNode = selNode.NextNode;
					else if(selNode.PrevNode != null)
						_treeView.SelectedNode = selNode.PrevNode;
					else
						_treeView.SelectedNode = selNode.Parent;

					// Delete node
					selNode.Parent.Nodes.Remove(selNode);
				}
			}
			_treeView.Select();
		}

		private void _entryUpButton_Click(object sender, EventArgs e)
		{
			// Is a node selected?
			TreeNode selNode = _treeView.SelectedNode;
			if(selNode == null)
				return;

			// Check whether there is a node above
			TreeNode prevNode = selNode.PrevNode;
			if(prevNode == null)
				return;

			// Swap nodes
			TreeNode parentNode = selNode.Parent;
			if(parentNode == null)
			{
				// Remove node and reinsert at the correct position
				_treeView.Nodes.Remove(selNode);
				_treeView.Nodes.Insert(_treeView.Nodes.IndexOf(prevNode), selNode);
			}
			else
			{
				// Remove node and reinsert at the correct position
				parentNode.Nodes.Remove(selNode);
				parentNode.Nodes.Insert(parentNode.Nodes.IndexOf(prevNode), selNode);
			}
			_treeView.SelectedNode = selNode;
			_treeView.Select();
		}

		private void _entryDownButton_Click(object sender, EventArgs e)
		{
			// Is a node selected?
			TreeNode selNode = _treeView.SelectedNode;
			if(selNode == null)
				return;

			// Check whether there is a node below
			TreeNode nextNode = selNode.NextNode;
			if(nextNode == null)
				return;

			// Swap nodes
			TreeNode parentNode = selNode.Parent;
			if(parentNode == null)
			{
				// Remove node and reinsert at the correct position
				_treeView.Nodes.Remove(selNode);
				_treeView.Nodes.Insert(_treeView.Nodes.IndexOf(nextNode) + 1, selNode);
			}
			else
			{
				// Remove node and reinsert at the correct position
				parentNode.Nodes.Remove(selNode);
				parentNode.Nodes.Insert(parentNode.Nodes.IndexOf(nextNode) + 1, selNode);
			}
			_treeView.SelectedNode = selNode;
			_treeView.Select();
		}


		private void _treeView_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			// If shift is pressed, collapse whole subtree
			if(ModifierKeys.HasFlag(Keys.Shift))
				e.Node.Collapse(false);
		}

		private void _treeView_AfterExpand(object sender, TreeViewEventArgs e)
		{
			// If shift is pressed, expand whole subtree
			if(ModifierKeys.HasFlag(Keys.Shift))
				e.Node.ExpandAll();
		}

		private void _typeUnitButton_CheckedChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change item type
			if(_typeUnitButton.Checked)
				_selectedElement.ElementType = TechTreeNew.TechTreeElement.ItemType.Creatable;

			// Update display
			UpdateNodeDisplay(_treeView.SelectedNode);
		}

		private void _typeBuildingButton_CheckedChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change item type
			if(_typeBuildingButton.Checked)
				_selectedElement.ElementType = TechTreeNew.TechTreeElement.ItemType.Building;

			// Update display
			UpdateNodeDisplay(_treeView.SelectedNode);
		}

		private void _typeResearchButton_CheckedChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change item type
			if(_typeResearchButton.Checked)
				_selectedElement.ElementType = TechTreeNew.TechTreeElement.ItemType.Research;

			// Update display
			UpdateNodeDisplay(_treeView.SelectedNode);
		}

		private void _idField_ValueChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change item ID
			_selectedElement.ElementObjectID = (short)_idField.Value;

			// Update display
			UpdateNodeDisplay(_treeView.SelectedNode);
		}

		private void _ageField_ValueChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change item age
			_selectedElement.Age = (byte)(_ageField.Value - 1);

			// Update display
			UpdateNodeDisplay(_treeView.SelectedNode);

			// Update sub nodes recursively
			Action<TreeNode> recAgeUpdate = null;
			recAgeUpdate = (node) =>
			{
				// Set age
				((TechTreeNew.TechTreeElement)node.Tag).Age = Math.Max(((TechTreeNew.TechTreeElement)node.Tag).Age, _selectedElement.Age);

				// Update display 
				UpdateNodeDisplay(node);

				// Update children
				foreach(TreeNode child in node.Nodes)
					recAgeUpdate(child);
			};
			foreach(TreeNode child in _treeView.SelectedNode.Nodes)
				recAgeUpdate(child);
		}

		private void _renderModeStandardButton_CheckedChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change render mode
			if(_renderModeStandardButton.Checked)
				_selectedElement.RenderMode = TechTreeNew.TechTreeElement.ItemRenderMode.Standard;
		}

		private void _renderModeHideButton_CheckedChanged(object sender, EventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Change render mode
			if(_renderModeHideButton.Checked)
				_selectedElement.RenderMode = TechTreeNew.TechTreeElement.ItemRenderMode.HideIfDisabled;
		}

		private void _civsList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Get item civ ID
			byte civId = ((KeyValuePair<byte, string>)_civsList.Items[e.Index]).Key;
			if(e.NewValue == CheckState.Checked && _selectedElement.DisableCivs.Contains(civId))
				_selectedElement.DisableCivs.Remove(civId);
			else if(e.NewValue == CheckState.Unchecked && !_selectedElement.DisableCivs.Contains(civId))
				_selectedElement.DisableCivs.Add(civId);
		}

		private void _civsAllButton_Click(object sender, EventArgs e)
		{
			// Enable all civs
			for(int i = 0; i < _civsList.Items.Count; ++i)
				_civsList.SetItemChecked(i, true);
		}

		private void _civsNoneButton_Click(object sender, EventArgs e)
		{
			// Disable all civs
			for(int i = 0; i < _civsList.Items.Count; ++i)
				_civsList.SetItemChecked(i, false);
		}

		private void _civsInvertButton_Click(object sender, EventArgs e)
		{
			// Invert all civs
			for(int i = 0; i < _civsList.Items.Count; ++i)
				_civsList.SetItemChecked(i, !_civsList.GetItemChecked(i));
		}

		private void _treeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			// Do drag drop
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void _treeView_DragEnter(object sender, DragEventArgs e)
		{
			// Only move
			e.Effect = DragDropEffects.Move;
		}

		private void _treeView_DragDrop(object sender, DragEventArgs e)
		{
			// Is a tree node dragged?
			if(e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
			{
				// Get destination node
				TreeNode destNode = _treeView.GetNodeAt(_treeView.PointToClient(new Point(e.X, e.Y)));

				// Get moved node
				TreeNode movedNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
				if(movedNode != destNode)
				{
					// Remove node from tree view
					if(movedNode.Parent == null)
						_treeView.Nodes.Remove(movedNode);
					else
						movedNode.Parent.Nodes.Remove(movedNode);

					// Insert at end of destination node (or as last parent element)
					if(destNode == null)
						_treeView.Nodes.Add(movedNode);
					else
					{
						// Insert at end of destination node
						destNode.Nodes.Add(movedNode);

						// Update sub nodes recursively
						Action<TreeNode> recAgeUpdate = null;
						recAgeUpdate = (node) =>
						{
							// Set age
							((TechTreeNew.TechTreeElement)node.Tag).Age = Math.Max(((TechTreeNew.TechTreeElement)node.Tag).Age, ((TechTreeNew.TechTreeElement)destNode.Tag).Age);

							// Update display 
							UpdateNodeDisplay(node);

							// Update children
							foreach(TreeNode child in node.Nodes)
								recAgeUpdate(child);
						};
						recAgeUpdate(movedNode);
					}
				}
			}
		}

		private void _requirementsView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// Updating?
			if(_updating)
				return;

			// Simply copy view content to selected element
			_selectedElement.RequiredElements = new List<Tuple<TechTreeNew.TechTreeElement.ItemType, short>>();
			foreach(DataGridViewRow row in _requirementsView.Rows)
			{
				// Check for valid row
				if(row.IsNewRow || row.Cells[0] == null || row.Cells[1] == null)
					continue;

				// Convert enum
				string selTypeStr = (string)((DataGridViewComboBoxCell)row.Cells[0]).FormattedValue;
				TechTreeNew.TechTreeElement.ItemType type = TechTreeNew.TechTreeElement.ItemType.Research;
				if(selTypeStr == "Unit")
					type = TechTreeNew.TechTreeElement.ItemType.Creatable;
				else if(selTypeStr == "Building")
					type = TechTreeNew.TechTreeElement.ItemType.Building;
				else if(selTypeStr != "Research")
					((DataGridViewComboBoxCell)row.Cells[0]).Value = "Research";

				// Convert ID
				short id;
				if(!short.TryParse((string)row.Cells[1].Value, out id))
				{
					// Error
					if(!string.IsNullOrEmpty((string)row.Cells[1].Value))
						MessageBox.Show("Invalid ID: Assuming 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					row.Cells[1].Value = "0";
					id = 0;
				}

				// Create entry
				_selectedElement.RequiredElements.Add(new Tuple<TechTreeNew.TechTreeElement.ItemType, short>(type, id));
			}

			// Update element display
			UpdateNodeDisplay(_treeView.SelectedNode);
		}

		private void _requirementsView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			// Call cell edit event
			_requirementsView_CellEndEdit(sender, null);
		}

		#endregion
	}
}
