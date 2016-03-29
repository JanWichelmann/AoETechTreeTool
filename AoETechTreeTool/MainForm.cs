using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AoETechTreeTool
{
	public partial class MainForm : Form
	{
		#region Variables

		/// <summary>
		/// The edited DAT file.
		/// </summary>
		private GenieLibrary.GenieFile _datFile = null;

		// The language DLL handles
		private GenieLibrary.LanguageFileWrapper _langDllWrapper = null;

		#endregion

		#region Functions

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			// Load controls
			InitializeComponent();
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
				_datFile.TechTreeNew = new GenieLibrary.DataElements.TechTreeNew() { ParentElements = new List<GenieLibrary.DataElements.TechTreeNew.TechTreeElement>() };
			}

			// Run recursively through elements and create nodes
			Func<GenieLibrary.DataElements.TechTreeNew.TechTreeElement, TreeNode> recursiveTreeViewFill = null;
			recursiveTreeViewFill = (element) =>
			  {
				  // Create node
				  TreeNode elementNode = new TreeNode(GetElementName(element));
				  elementNode.Tag = element;

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
		/// Returns the name of the given tech tree element.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		private string GetElementName(GenieLibrary.DataElements.TechTreeNew.TechTreeElement element)
		{
			// Switch by type
			if(element.ElementType == GenieLibrary.DataElements.TechTreeNew.TechTreeElement.ItemType.Research)
			{
				// Check for existence
				if(_datFile.Researches.Count <= element.ElementObjectID || element.ElementObjectID < 0)
					return "INVALID ID";
				string result = _langDllWrapper.GetString(_datFile.Researches[element.ElementObjectID].LanguageDLLName1);
				if(result == "")
					return _datFile.Researches[element.ElementObjectID].Name;
				return result;
			}
			else
			{
				// Check for existence
				if(!_datFile.Civs[0].Units.ContainsKey(element.ElementObjectID))
					return "INVALID ID";
				string result = _langDllWrapper.GetString(_datFile.Civs[0].Units[element.ElementObjectID].LanguageDLLName);
				if(result == "")
					return _datFile.Civs[0].Units[element.ElementObjectID].Name1;
				return result;
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
				_datFile = new GenieLibrary.GenieFile(GenieLibrary.GenieFile.DecompressData(compressedFile));
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
				_langDllWrapper = new GenieLibrary.LanguageFileWrapper(_openLangDllDialog.FileNames);
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

			// Update tree view
			RefillTreeView();
		}

		private void _saveDataButton_Click(object sender, EventArgs e)
		{

		}

		private void _exportTreeButton_Click(object sender, EventArgs e)
		{

		}

		private void _importTreeButton_Click(object sender, EventArgs e)
		{

		}

		private void _entryNewButton_Click(object sender, EventArgs e)
		{

		}

		private void _entryDeleteButton_Click(object sender, EventArgs e)
		{

		}

		private void _entryUpButton_Click(object sender, EventArgs e)
		{

		}

		private void _entryDownButton_Click(object sender, EventArgs e)
		{

		}

		#endregion
	}
}
