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
		private GenieLibrary.GenieFile _datFile =null;

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

		// Rebuilds the tree in the tree view from the DAT data.
		private void RefillTreeView()
		{
			// Is the new tech tree structure used?
			if(_datFile==null || _datFile)
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
				_datFile = new GenieLibrary.GenieFile(_openDatFileDialog.FileName);
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("Error loading DAT file: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
