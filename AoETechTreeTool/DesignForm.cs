using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenieLibrary.DataElements;

namespace AoETechTreeTool
{
	/// <summary>
	/// Allows editing the tech tree design.
	/// </summary>
	public partial class DesignForm : Form
	{
		#region Variables

		/// <summary>
		/// The edited DAT file.
		/// </summary>
		private GenieLibrary.GenieFile _datFile = null;

		/// <summary>
		/// Specifies if currently an updating process is active. This suppresses various change/edit events.
		/// </summary>
		private bool _updating = false;

		#endregion

		#region Functions

		/// <summary>
		/// Creates a new design editing form.
		/// </summary>
		/// <param name="datFile">The edited DAT file.</param>
		public DesignForm(GenieLibrary.GenieFile datFile)
		{
			// Create controls
			InitializeComponent();

			// Load existing design, fill controls
			_datFile=datFile;
			RefillControlsFromData();
		}

		/// <summary>
		/// Fills the controls with the design data from the DAT file.
		/// </summary>
		private void RefillControlsFromData()
		{
			// Updating
			_updating = true;

			// Set values
			_slpNodeBoxIdBox.Value = _datFile.TechTreeNew.DesignData.NodeSlpId;
			_slpNodeBoxNameBox.Text = _datFile.TechTreeNew.DesignData.NodeSlpFileName;
			_slpArrowButtonIdBox.Value = _datFile.TechTreeNew.DesignData.ScrollSlpId;
			_slpArrowButtonNameBox.Text = _datFile.TechTreeNew.DesignData.ScrollSlpFileName;
			_slpBackgroundTileIdBox.Value = _datFile.TechTreeNew.DesignData.TileSlpId;
			_slpBackgroundTileNameBox.Text = _datFile.TechTreeNew.DesignData.TileSlpFileName;
			_slpLegendAndAgesIdBox.Value = _datFile.TechTreeNew.DesignData.LegendAgesSlpId;
			_slpLegendAndAgesNameBox.Text = _datFile.TechTreeNew.DesignData.LegendAgesSlpFileName;
			_slpLegendDisabledIdBox.Value = _datFile.TechTreeNew.DesignData.LegendDisableSlpId;
			_slpLegendDisabledNameBox.Text = _datFile.TechTreeNew.DesignData.LegendDisableSlpFileName;
			_mouseScrollAreaBox.Value = _datFile.TechTreeNew.DesignData.MouseScrollArea;
			_mouseScrollDelayBox.Value = _datFile.TechTreeNew.DesignData.MouseScrollDelay;
			_mouseScrollAmountBox.Value = _datFile.TechTreeNew.DesignData.MouseScrollOffset;
			_keyboardScrollAmountBox.Value = _datFile.TechTreeNew.DesignData.KeyScrollOffset;

			// Set rectangles
			_closeButtonXBox.Value = _datFile.TechTreeNew.DesignData.CloseButtonRelativeRectangle.X;
			_closeButtonYBox.Value = _datFile.TechTreeNew.DesignData.CloseButtonRelativeRectangle.Y;
			_closeButtonWidthBox.Value = _datFile.TechTreeNew.DesignData.CloseButtonRelativeRectangle.Width;
			_closeButtonHeightBox.Value = _datFile.TechTreeNew.DesignData.CloseButtonRelativeRectangle.Height;
			_scrollLeftButtonXBox.Value = _datFile.TechTreeNew.DesignData.ScrollLeftButtonRelativeRectangle.X;
			_scrollLeftButtonYBox.Value = _datFile.TechTreeNew.DesignData.ScrollLeftButtonRelativeRectangle.Y;
			_scrollLeftButtonWidthBox.Value = _datFile.TechTreeNew.DesignData.ScrollLeftButtonRelativeRectangle.Width;
			_scrollLeftButtonHeightBox.Value = _datFile.TechTreeNew.DesignData.ScrollLeftButtonRelativeRectangle.Height;
			_scrollRightButtonXBox.Value = _datFile.TechTreeNew.DesignData.ScrollRightButtonRelativeRectangle.X;
			_scrollRightButtonYBox.Value = _datFile.TechTreeNew.DesignData.ScrollRightButtonRelativeRectangle.Y;
			_scrollRightButtonWidthBox.Value = _datFile.TechTreeNew.DesignData.ScrollRightButtonRelativeRectangle.Width;
			_scrollRightButtonHeightBox.Value = _datFile.TechTreeNew.DesignData.ScrollRightButtonRelativeRectangle.Height;

			// Set values
			_popupDelayBox.Value = _datFile.TechTreeNew.DesignData.PopupLabelDelay;
			_popupWidthBox.Value = _datFile.TechTreeNew.DesignData.PopupLabelWidth;
			_popupBoxPaddingBox.Value = _datFile.TechTreeNew.DesignData.PopupInnerPadding;
			_popupBevel1Box.Value = _datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices[0];
			_popupBevel2Box.Value = _datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices[1];
			_popupBevel3Box.Value = _datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices[2];
			_popupBevel4Box.Value = _datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices[3];
			_popupBevel5Box.Value = _datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices[4];
			_popupBevel6Box.Value = _datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices[5];
			_nodeFontBox.Value = _datFile.TechTreeNew.DesignData.NodeFontIndex;

			// Fill resolution list box
			_resolutionListBox.Items.Clear();
			foreach(var currRes in _datFile.TechTreeNew.DesignData.ResolutionData)
				_resolutionListBox.Items.Add(currRes.Key);

			// Fill node background list box
			_nodeBackgroundsListBox.Items.Clear();
			foreach(var currNB in _datFile.TechTreeNew.DesignData.NodeBackgrounds)
				_nodeBackgroundsListBox.Items.Add(currNB);

			// Updating finished
			_updating = false;

			// Select 0 elements
			_resolutionListBox.SelectedItem = 0;
			_nodeBackgroundsListBox.SelectedIndex = 0;
		}

		#endregion

		#region Event handlers

		private void DesignForm_Shown(object sender, EventArgs e)
		{
			// Redraw bevel preview
			_updating = true;
			_popupBevelBox_ValueChanged(sender, e);
			_updating = false;
		}

		private void _exportDesignButton_Click(object sender, EventArgs e)
		{
			// Show save dialog
			if(_saveDesignDialog.ShowDialog() != DialogResult.OK)
				return;

			// Save design
			//try
			{
				// Write into buffer
				IORAMHelper.RAMBuffer buffer = new IORAMHelper.RAMBuffer();
				_datFile.TechTreeNew.DesignData.WriteData(buffer);

				// Save buffer
				buffer.Save(_saveDesignDialog.FileName);
			}
			//catch(Exception ex)
			{
				// Message
				//MessageBox.Show("Error exporting tech tree design: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//return;
			}
		}

		private void _importDesignButton_Click(object sender, EventArgs e)
		{
			// Show open dialog
			if(_openDesignDialog.ShowDialog() != DialogResult.OK)
				return;

			// Load data and update tree view
			//try
			{
				// Load data from file
				IORAMHelper.RAMBuffer buffer = new IORAMHelper.RAMBuffer(_openDesignDialog.FileName);
				_datFile.TechTreeNew.DesignData = new TechTreeNew.TechTreeDesign();
				_datFile.TechTreeNew.DesignData.ReadData(buffer);

				// Update view
				RefillControlsFromData();
			}
			//catch(Exception ex)
			{
				// Message
				//MessageBox.Show("Error importing tech tree design: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//return;
			}
		}

		private void _slpNodeBoxIdBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.NodeSlpId = (int)_slpNodeBoxIdBox.Value;
		}

		private void _slpNodeBoxNameBox_TextChanged(object sender, EventArgs e)
		{
			// Save name
			_datFile.TechTreeNew.DesignData.NodeSlpFileName = _slpNodeBoxNameBox.Text;
		}

		private void _slpArrowButtonIdBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.ScrollSlpId = (int)_slpArrowButtonIdBox.Value;
		}

		private void _slpArrowButtonNameBox_TextChanged(object sender, EventArgs e)
		{
			// Save name
			_datFile.TechTreeNew.DesignData.ScrollSlpFileName = _slpArrowButtonNameBox.Text;
		}

		private void _slpBackgroundTileIdBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.TileSlpId = (int)_slpBackgroundTileIdBox.Value;
		}

		private void _slpBackgroundTileNameBox_TextChanged(object sender, EventArgs e)
		{
			// Save name
			_datFile.TechTreeNew.DesignData.TileSlpFileName = _slpBackgroundTileNameBox.Text;
		}

		private void _slpLegendAndAgesIdBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.LegendAgesSlpId = (int)_slpLegendAndAgesIdBox.Value;
		}

		private void _slpLegendAndAgesNameBox_TextChanged(object sender, EventArgs e)
		{
			// Save name
			_datFile.TechTreeNew.DesignData.LegendAgesSlpFileName = _slpLegendAndAgesNameBox.Text;
		}

		private void _slpLegendDisabledIdBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.LegendDisableSlpId = (int)_slpLegendDisabledIdBox.Value;
		}

		private void _slpLegendDisabledNameBox_TextChanged(object sender, EventArgs e)
		{
			// Save name
			_datFile.TechTreeNew.DesignData.LegendDisableSlpFileName = _slpLegendDisabledNameBox.Text;
		}

		private void _mouseScrollAreaBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.MouseScrollArea = (int)_mouseScrollAreaBox.Value;
		}

		private void _mouseScrollDelayBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.MouseScrollDelay = (int)_mouseScrollDelayBox.Value;
		}

		private void _mouseScrollAmountBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.MouseScrollOffset = (int)_mouseScrollAmountBox.Value;
		}

		private void _keyboardScrollAmountBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.KeyScrollOffset = (int)_keyboardScrollAmountBox.Value;
		}

		private void _closeButtonBox_ValueChanged(object sender, EventArgs e)
		{
			// Prevent accidental changes
			if(_updating)
				return;

			// Save rectangle
			_datFile.TechTreeNew.DesignData.CloseButtonRelativeRectangle = new Rectangle((int)_closeButtonXBox.Value, (int)_closeButtonYBox.Value, (int)_closeButtonWidthBox.Value, (int)_closeButtonHeightBox.Value);
		}

		private void _scrollLeftButtonBox_ValueChanged(object sender, EventArgs e)
		{
			// Prevent accidental changes
			if(_updating)
				return;

			// Save rectangle
			_datFile.TechTreeNew.DesignData.ScrollLeftButtonRelativeRectangle = new Rectangle((int)_scrollLeftButtonXBox.Value, (int)_scrollLeftButtonYBox.Value, (int)_scrollLeftButtonWidthBox.Value, (int)_scrollLeftButtonHeightBox.Value);
		}

		private void _scrollRightButtonBox_ValueChanged(object sender, EventArgs e)
		{
			// Prevent accidental changes
			if(_updating)
				return;

			// Save rectangle
			_datFile.TechTreeNew.DesignData.ScrollRightButtonRelativeRectangle = new Rectangle((int)_scrollRightButtonXBox.Value, (int)_scrollRightButtonYBox.Value, (int)_scrollRightButtonWidthBox.Value, (int)_scrollRightButtonHeightBox.Value);
		}

		private void _popupDelayBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.PopupLabelDelay = (int)_popupDelayBox.Value;
		}

		private void _popupWidthBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.PopupLabelWidth = (int)_popupWidthBox.Value;
		}

		private void _popupBoxPaddingBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.PopupInnerPadding = (int)_popupBoxPaddingBox.Value;
		}

		private void _popupBevelBox_ValueChanged(object sender, EventArgs e)
		{
			// Update preview
			Graphics bevelDrawPanelGraphicHandle = _popupBevelDrawPanel.CreateGraphics();
			bevelDrawPanelGraphicHandle.Clear(Color.White);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel1Box.Value, 0)), 1, 0, _popupBevelDrawPanel.Width - 1, 0);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel2Box.Value, 0)), 2, 1, _popupBevelDrawPanel.Width - 2, 1);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel3Box.Value, 0)), 3, 2, _popupBevelDrawPanel.Width - 3, 2);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel1Box.Value, 0)), _popupBevelDrawPanel.Width - 1, 0, _popupBevelDrawPanel.Width - 1, _popupBevelDrawPanel.Height - 1);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel2Box.Value, 0)), _popupBevelDrawPanel.Width - 2, 1, _popupBevelDrawPanel.Width - 2, _popupBevelDrawPanel.Height - 2);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel3Box.Value, 0)), _popupBevelDrawPanel.Width - 3, 2, _popupBevelDrawPanel.Width - 3, _popupBevelDrawPanel.Height - 3);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel4Box.Value, 0)), 0, 0, 0, _popupBevelDrawPanel.Height - 1);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel5Box.Value, 0)), 1, 1, 1, _popupBevelDrawPanel.Height - 2);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel6Box.Value, 0)), 2, 2, 2, _popupBevelDrawPanel.Height - 3);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel4Box.Value, 0)), 0, _popupBevelDrawPanel.Height - 1, _popupBevelDrawPanel.Width - 1, _popupBevelDrawPanel.Height - 1);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel5Box.Value, 0)), 1, _popupBevelDrawPanel.Height - 2, _popupBevelDrawPanel.Width - 2, _popupBevelDrawPanel.Height - 2);
			bevelDrawPanelGraphicHandle.DrawLine(new Pen(Properties.Resources.pal50500.GetPixel((int)_popupBevel6Box.Value, 0)), 2, _popupBevelDrawPanel.Height - 3, _popupBevelDrawPanel.Width - 3, _popupBevelDrawPanel.Height - 3);

			// Prevent accidental changes
			if(_updating)
				return;

			// Save values
			_datFile.TechTreeNew.DesignData.PopupBoxBevelColorIndices = new List<byte>(new byte[]
			{
				(byte)_popupBevel1Box.Value,
				(byte)_popupBevel2Box.Value,
				(byte)_popupBevel3Box.Value,
				(byte)_popupBevel4Box.Value,
				(byte)_popupBevel5Box.Value,
				(byte)_popupBevel6Box.Value,
			});
		}

		private void _nodeFontBox_ValueChanged(object sender, EventArgs e)
		{
			// Save value
			_datFile.TechTreeNew.DesignData.NodeFontIndex = (byte)_nodeFontBox.Value;
		}

		private void _resolutionListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Prevent accidental changes
			if(_updating)
				return;
			_updating = true;

			// Show entry
			if(_resolutionListBox.SelectedItem == null)
				_resolutionListBox.SelectedItem = 0;
			int selectedResHeight = (int)_resolutionListBox.SelectedItem;
			_resolutionSettingsGrid.SelectedObject = new PropertyGridResolutionData(_datFile.TechTreeNew.DesignData.ResolutionData[selectedResHeight]);
			_minimumResolutionBox.Value = selectedResHeight;
			_minimumResolutionBox.Enabled = (selectedResHeight != 0);

			// Finished
			_updating = false;
		}

		private void _minimumResolutionBox_ValueChanged(object sender, EventArgs e)
		{
			// Updating
			if(_updating)
				return;
			_updating = true;

			// Ensure resolution doesn't exist already
			while(_resolutionListBox.Items.Contains((int)_minimumResolutionBox.Value) && _minimumResolutionBox.Value <= _minimumResolutionBox.Maximum - 1)
				++_minimumResolutionBox.Value;

			// Change resolution
			int selectedResHeight = (int)_resolutionListBox.SelectedItem;
			int selectedResIndex = _resolutionListBox.SelectedIndex;
			_resolutionListBox.Items.Remove(selectedResHeight);
			_resolutionListBox.Items.Insert(selectedResIndex, (int)_minimumResolutionBox.Value);
			_resolutionListBox.SelectedIndex = selectedResIndex;

			// Update resolution data
			GenieLibrary.DataElements.TechTreeNew.TechTreeDesign.ResolutionConfiguration rConf = _datFile.TechTreeNew.DesignData.ResolutionData[selectedResHeight];
			_datFile.TechTreeNew.DesignData.ResolutionData.Remove(selectedResHeight);
			_datFile.TechTreeNew.DesignData.ResolutionData[(int)_minimumResolutionBox.Value] = rConf;

			// Finished
			_updating = false;
		}

		private void _addResolutionButton_Click(object sender, EventArgs e)
		{
			// Create new resolution data object based on selected one
			GenieLibrary.DataElements.TechTreeNew.TechTreeDesign.ResolutionConfiguration selectedResConf = _datFile.TechTreeNew.DesignData.ResolutionData[(int)_resolutionListBox.SelectedItem];
			TechTreeNew.TechTreeDesign.ResolutionConfiguration newRes = new TechTreeNew.TechTreeDesign.ResolutionConfiguration()
			{
				LegendFrameIndex = selectedResConf.LegendFrameIndex,
				AgeFrameIndex = selectedResConf.AgeFrameIndex,
				TileFrameIndex = selectedResConf.TileFrameIndex,
				LegendDisableSlpDrawPosition = selectedResConf.LegendDisableSlpDrawPosition,
				CivBonusLabelRectangle = selectedResConf.CivBonusLabelRectangle,
				CivSelectionComboBoxRectangle = selectedResConf.CivSelectionComboBoxRectangle,
				CivSelectionTitleLabelRectangle = selectedResConf.CivSelectionTitleLabelRectangle,
				LegendLabelRectangles = new List<Rectangle>(selectedResConf.LegendLabelRectangles),
				AgeLabelRectangles = new List<Rectangle>(selectedResConf.AgeLabelRectangles),
				VerticalDrawOffsets = new List<int>(selectedResConf.VerticalDrawOffsets)
			};

			// Calculate new resolution height
			int newResHeight = (_datFile.TechTreeNew.DesignData.ResolutionData.Keys.Count > 0 ? _datFile.TechTreeNew.DesignData.ResolutionData.Keys.Max() + 1 : 0);

			// Add resolution data to internal list and list box
			_datFile.TechTreeNew.DesignData.ResolutionData.Add(newResHeight, newRes);
			_resolutionListBox.Items.Add(newResHeight);
			_resolutionListBox.SelectedItem = newResHeight;
		}

		private void _deleteResolutionButton_Click(object sender, EventArgs e)
		{
			// Element selected?
			if(_resolutionListBox.SelectedItems.Count == 0)
				return;

			// 0 can't be deleted
			if((int)_resolutionListBox.SelectedItem == 0)
			{
				// Error
				MessageBox.Show("The '0' element can't be deleted.", "Delete resolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Delete element
			_datFile.TechTreeNew.DesignData.ResolutionData.Remove((int)_resolutionListBox.SelectedItem);
			_resolutionListBox.Items.Remove(_resolutionListBox.SelectedItem);
			_resolutionSettingsGrid.SelectedObject = _datFile.TechTreeNew.DesignData.ResolutionData[(int)_resolutionListBox.SelectedItem];
		}

		private void _resolutionSettingsGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
		{
			// Call leave event handler for saving changes
			_resolutionSettingsGrid_Leave(sender, e);
		}

		private void _resolutionSettingsGrid_Leave(object sender, EventArgs e)
		{
			// Prevent accidental changes
			if(_updating)
				return;

			// Copy values to design data
			_datFile.TechTreeNew.DesignData.ResolutionData[(int)_resolutionListBox.SelectedItem] = (PropertyGridResolutionData)_resolutionSettingsGrid.SelectedObject;

			// Check list lengths
			if(_datFile.TechTreeNew.DesignData.ResolutionData[(int)_resolutionListBox.SelectedItem].AgeLabelRectangles.Count < 2)
				MessageBox.Show("Warning: There must be at least three age label rectangles!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			if(_datFile.TechTreeNew.DesignData.ResolutionData[(int)_resolutionListBox.SelectedItem].VerticalDrawOffsets.Count < 2)
				MessageBox.Show("Warning: There must be at least three age draw offsets!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void _nodeBackgroundIndexField_ValueChanged(object sender, EventArgs e)
		{
			// Updating
			if(_updating)
				return;
			_updating = true;

			// Fetch and update current element
			TechTreeNew.TechTreeDesign.NodeBackground selectedNodeBackground = _datFile.TechTreeNew.DesignData.NodeBackgrounds[_nodeBackgroundsListBox.SelectedIndex];
			selectedNodeBackground.FrameIndex = (int)_nodeBackgroundIndexField.Value;
			_nodeBackgroundsListBox.Items[_nodeBackgroundsListBox.SelectedIndex] = selectedNodeBackground;

			// Finished
			_updating = false;
		}

		private void _nodeBackgroundNameBox_TextChanged(object sender, EventArgs e)
		{
			// Updating
			if(_updating)
				return;
			_updating = true;

			// Fetch and update current element
			TechTreeNew.TechTreeDesign.NodeBackground selectedNodeBackground = _datFile.TechTreeNew.DesignData.NodeBackgrounds[_nodeBackgroundsListBox.SelectedIndex];
			selectedNodeBackground.Name = _nodeBackgroundNameBox.Text;
			_nodeBackgroundsListBox.Items[_nodeBackgroundsListBox.SelectedIndex] = selectedNodeBackground;

			// Finished
			_updating = false;
		}

		private void _nodeBackgroundsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Prevent accidental changes
			if(_updating)
				return;
			_updating = true;

			// Select first item if none is selected
			if(_nodeBackgroundsListBox.SelectedItem == null)
				_nodeBackgroundsListBox.SelectedIndex = 0;

			// Fill controls
			TechTreeNew.TechTreeDesign.NodeBackground selectedNodeBackground = _datFile.TechTreeNew.DesignData.NodeBackgrounds[_nodeBackgroundsListBox.SelectedIndex];
			_nodeBackgroundNameBox.Text = selectedNodeBackground.Name;
			_nodeBackgroundIndexField.Value = selectedNodeBackground.FrameIndex;

			// Finished
			_updating = false;
		}

		private void _nodeBackgroundsListBox_Format(object sender, ListControlConvertEventArgs e)
		{
			// Display whole element data
			var selectedNodeBackground = (TechTreeNew.TechTreeDesign.NodeBackground)e.ListItem;
			if(e.DesiredType == typeof(string))
				e.Value = $"[{_nodeBackgroundsListBox.Items.IndexOf(selectedNodeBackground)}] Frame {selectedNodeBackground.FrameIndex}: {selectedNodeBackground.Name}";
		}

		private void _addNodeBackgroundButton_Click(object sender, EventArgs e)
		{
			// Create new node background data object based on selected one
			TechTreeNew.TechTreeDesign.NodeBackground selectedNodeBackground = _datFile.TechTreeNew.DesignData.NodeBackgrounds[_nodeBackgroundsListBox.SelectedIndex];
			TechTreeNew.TechTreeDesign.NodeBackground newNodeBackground = new TechTreeNew.TechTreeDesign.NodeBackground()
			{
				Name = selectedNodeBackground.Name,
				FrameIndex = selectedNodeBackground.FrameIndex
			};

			// Add object to list box and to internal list
			_datFile.TechTreeNew.DesignData.NodeBackgrounds.Add(newNodeBackground);
			_nodeBackgroundsListBox.Items.Add(newNodeBackground);
			_nodeBackgroundsListBox.SelectedItem = newNodeBackground;
		}

		private void _deleteNodeBackgroundButton_Click(object sender, EventArgs e)
		{
			// Element selected?
			// Also deny deletion if there are only three elements left
			if(_nodeBackgroundsListBox.SelectedItems.Count == 0 || _nodeBackgroundsListBox.Items.Count <= 3)
				return;

			// Delete element
			_datFile.TechTreeNew.DesignData.NodeBackgrounds.Remove((TechTreeNew.TechTreeDesign.NodeBackground)_nodeBackgroundsListBox.SelectedItem);
			_nodeBackgroundsListBox.Items.Remove(_nodeBackgroundsListBox.SelectedItem);
		}

		#endregion

		#region Structures

		/// <summary>
		/// Helper class for the resolution settings property grid.
		/// </summary>
		public class PropertyGridResolutionData
		{
			[Category("Frame indices")]
			[DisplayName("Legend background frame index")]
			[Description("The index of the legend background for the current resolution.")]
			public int LegendFrameIndex { get; set; }

			[Category("Frame indices")]
			[DisplayName("Age bar frame index")]
			[Description("The base index of the age bar frames for the current resolution.")]
			public int AgeFrameIndex { get; set; }

			[Category("Frame indices")]
			[DisplayName("Tile graphic frame index")]
			[Description("The frame index of the background tile graphic for the current resolution.")]
			public int TileFrameIndex { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Disabled\" SLP draw position")]
			[Description("The draw position of the \"disabled\" icon in the legend.")]
			public Point LegendDisableSlpDrawPosition { get; set; }

			[Category("Legend top")]
			[DisplayName("Civ bonus label rectangle")]
			[Description("The rectangle of the civ description label.")]
			public Rectangle CivBonusLabelRectangle { get; set; }

			[Category("Legend top")]
			[DisplayName("Civ selection box rectangle")]
			[Description("The rectangle of the civ selection box.")]
			public Rectangle CivSelectionComboBoxRectangle { get; set; }

			[Category("Legend top")]
			[DisplayName("Civ selection label rectangle")]
			[Description("The rectangle of the label above the civ selection box.")]
			public Rectangle CivSelectionTitleLabelRectangle { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Not researched\" label rectangle")]
			[Description("The rectangle of the \"Not researched\" label.")]
			public Rectangle LegendLabelRectangle1 { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Researched\" label rectangle")]
			[Description("The rectangle of the \"Researched\" label.")]
			public Rectangle LegendLabelRectangle2 { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Units\" label rectangle")]
			[Description("The rectangle of the \"Units\" label.")]
			public Rectangle LegendLabelRectangle3 { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Buildings\" label rectangle")]
			[Description("The rectangle of the \"Buildings\" label.")]
			public Rectangle LegendLabelRectangle4 { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Technologies\" label rectangle")]
			[Description("The rectangle of the \"Technologies\" label.")]
			public Rectangle LegendLabelRectangle5 { get; set; }

			[Category("Legend bottom")]
			[DisplayName("\"Not available\" label rectangle")]
			[Description("The rectangle of the \"Not available\" label.")]
			public Rectangle LegendLabelRectangle6 { get; set; }

			[Category("Tree drawing related")]
			[DisplayName("Age label rectangles")]
			[Description("The rectangles of the left side age labels. There should be always two rectangles per age, one for the first and one for the second row (in that order). At least three rectangles must be defined, the missing ones are calculated by the renderer.")]
			public List<RectangleF> AgeLabelRectangles { get; set; } // RectangleF because the collection editor does not work properly with Rectangle for strange reasons

			[Category("Tree drawing related")]
			[DisplayName("Vertical draw offsets")]
			[Description("The Y-offsets for the tree nodes, beginning on the top. There are always two per age, as every age can contain two rows of nodes (first item for upper row, second item for lower row). At least three offsets must be defined, the missing ones are calculated by the renderer.")]
			public List<int> VerticalDrawOffsets { get; set; }

			public PropertyGridResolutionData(TechTreeNew.TechTreeDesign.ResolutionConfiguration config)
			{
				// Copy values
				LegendFrameIndex = config.LegendFrameIndex;
				AgeFrameIndex = config.AgeFrameIndex;
				TileFrameIndex = config.TileFrameIndex;
				LegendDisableSlpDrawPosition = config.LegendDisableSlpDrawPosition;
				CivBonusLabelRectangle = config.CivBonusLabelRectangle;
				CivSelectionComboBoxRectangle = config.CivSelectionComboBoxRectangle;
				CivSelectionTitleLabelRectangle = config.CivSelectionTitleLabelRectangle;
				LegendLabelRectangle1 = config.LegendLabelRectangles[0];
				LegendLabelRectangle2 = config.LegendLabelRectangles[1];
				LegendLabelRectangle3 = config.LegendLabelRectangles[2];
				LegendLabelRectangle4 = config.LegendLabelRectangles[3];
				LegendLabelRectangle5 = config.LegendLabelRectangles[4];
				LegendLabelRectangle6 = config.LegendLabelRectangles[5];
				AgeLabelRectangles = new List<RectangleF>(CastRectangleList(config.AgeLabelRectangles));
				VerticalDrawOffsets = new List<int>(config.VerticalDrawOffsets);
			}

			public static implicit operator TechTreeNew.TechTreeDesign.ResolutionConfiguration(PropertyGridResolutionData data)
			{
				// Copy values to new object
				return new TechTreeNew.TechTreeDesign.ResolutionConfiguration()
				{
					LegendFrameIndex = data.LegendFrameIndex,
					AgeFrameIndex = data.AgeFrameIndex,
					TileFrameIndex = data.TileFrameIndex,
					LegendDisableSlpDrawPosition = data.LegendDisableSlpDrawPosition,
					CivBonusLabelRectangle = data.CivBonusLabelRectangle,
					CivSelectionComboBoxRectangle = data.CivSelectionComboBoxRectangle,
					CivSelectionTitleLabelRectangle = data.CivSelectionTitleLabelRectangle,
					LegendLabelRectangles = new List<Rectangle>(new Rectangle[]
					{
						data.LegendLabelRectangle1,
						data.LegendLabelRectangle2,
						data.LegendLabelRectangle3,
						data.LegendLabelRectangle4,
						data.LegendLabelRectangle5,
						data.LegendLabelRectangle6
					}),
					AgeLabelRectangles = new List<Rectangle>(CastRectangleFList(data.AgeLabelRectangles)),
					VerticalDrawOffsets = new List<int>(data.VerticalDrawOffsets)
				};
			}

			/// <summary>
			/// Helper function to safely cast a Rectangle list to a RectangleF list.
			/// </summary>
			/// <param name="list">The Rectangle list to be casted.</param>
			/// <returns></returns>
			private static IEnumerable<RectangleF> CastRectangleList(List<Rectangle> list)
			{
				// Cast
				return list.Select(r => new RectangleF(r.X, r.Y, r.Width, r.Height));
			}

			/// <summary>
			/// Helper function to safely cast a RectangleF list to a Rectangle list.
			/// </summary>
			/// <param name="list">The RectangleF list to be casted.</param>
			/// <returns></returns>
			private static IEnumerable<Rectangle> CastRectangleFList(List<RectangleF> list)
			{
				// Cast
				return list.Select(rf => new Rectangle((int)rf.X, (int)rf.Y, (int)rf.Width, (int)rf.Height));
			}
		}

		#endregion
	}
}
