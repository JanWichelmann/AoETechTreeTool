using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AoETechTreeTool
{
	public partial class PathForm : Form
	{
		#region Variables

		/// <summary>
		/// The selected DAT file.
		/// </summary>
		public string SelectedDatFile { get; private set; }

		/// <summary>
		/// The selected DLL files.
		/// </summary>
		public string[] SelectedDllFiles { get; private set; }

		#endregion

		#region Functions

		/// <summary>
		/// Constructor.
		/// </summary>
		public PathForm()
		{
			// Create controls
			InitializeComponent();
		}

		#endregion

		#region Event handlers

		private void _dll1CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// Set control availability
			_dll1TextBox.Enabled = _dll1CheckBox.Checked;
			_dll1Button.Enabled = _dll1CheckBox.Checked;
		}

		private void _dll2CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// Set control availability
			_dll2TextBox.Enabled = _dll2CheckBox.Checked;
			_dll2Button.Enabled = _dll2CheckBox.Checked;
		}

		private void _dll3CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// Set control availability
			_dll3TextBox.Enabled = _dll3CheckBox.Checked;
			_dll3Button.Enabled = _dll3CheckBox.Checked;
		}

		#endregion

		private void _cancelButton_Click(object sender, EventArgs e)
		{
			// Cancel
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			// Check paths
			if(_datTextBox.Enabled && !File.Exists(_datTextBox.Text))
				if(MessageBox.Show("Your empires2_x1_p1.dat file path is invalid. Continue anyway?", "Invalid path", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					_datTextBox.Text = "";
				else return;
			if(_dll1TextBox.Enabled && !File.Exists(_dll1TextBox.Text))
				if(MessageBox.Show("Your language.dll file path is invalid. Continue anyway?", "Invalid path", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					_dll1TextBox.Text = "";
				else return;
			if(_dll2TextBox.Enabled && !File.Exists(_dll2TextBox.Text))
				if(MessageBox.Show("Your language_x1.dll file path is invalid. Continue anyway?", "Invalid path", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					_dll2TextBox.Text = "";
				else return;
			if(_dll3TextBox.Enabled && !File.Exists(_dll3TextBox.Text))
				if(MessageBox.Show("Your language_x1_p1.dll file path is invalid. Continue anyway?", "Invalid path", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					_dll3TextBox.Text = "";
				else return;

			// Set DAT file property
			SelectedDatFile = _datTextBox.Text;

			// Set DLL list property
			List<string> dllFiles = new List<string>();
			if(_dll1CheckBox.Checked && _dll1TextBox.Text != "")
				dllFiles.Add(_dll1TextBox.Text);
			if(_dll2CheckBox.Checked && _dll2TextBox.Text != "")
				dllFiles.Add(_dll2TextBox.Text);
			if(_dll3CheckBox.Checked && _dll3TextBox.Text != "")
				dllFiles.Add(_dll3TextBox.Text);
			SelectedDllFiles = dllFiles.ToArray();

			// OK
			DialogResult = DialogResult.OK;
			Close();
		}

		private void _datButton_Click(object sender, EventArgs e)
		{
			// Set dialog path
			try { _openDatFileDialog.InitialDirectory = Path.GetDirectoryName(_datTextBox.Text); } catch { }
			if(_openDatFileDialog.ShowDialog() == DialogResult.OK)
				_datTextBox.Text = _openDatFileDialog.FileName;
		}

		private void _dll1Button_Click(object sender, EventArgs e)
		{
			// Set dialog path
			try { _openLangDllDialog.InitialDirectory = Path.GetDirectoryName(_dll1TextBox.Text); } catch { }
			if(_openLangDllDialog.ShowDialog() == DialogResult.OK)
				_dll1TextBox.Text = _openLangDllDialog.FileName;
		}

		private void _dll2Button_Click(object sender, EventArgs e)
		{
			// Set dialog path
			try { _openLangDllDialog.InitialDirectory = Path.GetDirectoryName(_dll2TextBox.Text); } catch { }
			if(_openLangDllDialog.ShowDialog() == DialogResult.OK)
				_dll2TextBox.Text = _openLangDllDialog.FileName;
		}

		private void _dll3Button_Click(object sender, EventArgs e)
		{
			// Set dialog path
			try { _openLangDllDialog.InitialDirectory = Path.GetDirectoryName(_dll3TextBox.Text); } catch { }
			if(_openLangDllDialog.ShowDialog() == DialogResult.OK)
				_dll3TextBox.Text = _openLangDllDialog.FileName;
		}

		private void PathForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Save settings
			Properties.Settings.Default.Save();
		}
	}
}
