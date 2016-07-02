namespace AoETechTreeTool
{
	partial class PathForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._datButton = new System.Windows.Forms.Button();
			this._dll1Button = new System.Windows.Forms.Button();
			this._dll2Button = new System.Windows.Forms.Button();
			this._dll3Button = new System.Windows.Forms.Button();
			this._openDatFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._openLangDllDialog = new System.Windows.Forms.OpenFileDialog();
			this._dll3TextBox = new System.Windows.Forms.TextBox();
			this._dll3CheckBox = new System.Windows.Forms.CheckBox();
			this._dll2TextBox = new System.Windows.Forms.TextBox();
			this._dll2CheckBox = new System.Windows.Forms.CheckBox();
			this._dll1TextBox = new System.Windows.Forms.TextBox();
			this._dll1CheckBox = new System.Windows.Forms.CheckBox();
			this._datTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "empires2_x1_p1.dat:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "language.dll:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "language_x1.dll:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "language_x1_p1.dll:";
			// 
			// _okButton
			// 
			this._okButton.Location = new System.Drawing.Point(332, 116);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(100, 23);
			this._okButton.TabIndex = 12;
			this._okButton.Text = "Load";
			this._okButton.UseVisualStyleBackColor = true;
			this._okButton.Click += new System.EventHandler(this._okButton_Click);
			// 
			// _cancelButton
			// 
			this._cancelButton.Location = new System.Drawing.Point(438, 116);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(100, 23);
			this._cancelButton.TabIndex = 13;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.UseVisualStyleBackColor = true;
			this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
			// 
			// _datButton
			// 
			this._datButton.Location = new System.Drawing.Point(511, 12);
			this._datButton.Name = "_datButton";
			this._datButton.Size = new System.Drawing.Size(27, 20);
			this._datButton.TabIndex = 14;
			this._datButton.Text = "...";
			this._datButton.UseVisualStyleBackColor = true;
			this._datButton.Click += new System.EventHandler(this._datButton_Click);
			// 
			// _dll1Button
			// 
			this._dll1Button.Location = new System.Drawing.Point(511, 38);
			this._dll1Button.Name = "_dll1Button";
			this._dll1Button.Size = new System.Drawing.Size(27, 20);
			this._dll1Button.TabIndex = 15;
			this._dll1Button.Text = "...";
			this._dll1Button.UseVisualStyleBackColor = true;
			this._dll1Button.Click += new System.EventHandler(this._dll1Button_Click);
			// 
			// _dll2Button
			// 
			this._dll2Button.Location = new System.Drawing.Point(511, 64);
			this._dll2Button.Name = "_dll2Button";
			this._dll2Button.Size = new System.Drawing.Size(27, 20);
			this._dll2Button.TabIndex = 16;
			this._dll2Button.Text = "...";
			this._dll2Button.UseVisualStyleBackColor = true;
			this._dll2Button.Click += new System.EventHandler(this._dll2Button_Click);
			// 
			// _dll3Button
			// 
			this._dll3Button.Location = new System.Drawing.Point(511, 90);
			this._dll3Button.Name = "_dll3Button";
			this._dll3Button.Size = new System.Drawing.Size(27, 20);
			this._dll3Button.TabIndex = 17;
			this._dll3Button.Text = "...";
			this._dll3Button.UseVisualStyleBackColor = true;
			this._dll3Button.Click += new System.EventHandler(this._dll3Button_Click);
			// 
			// _openDatFileDialog
			// 
			this._openDatFileDialog.FileName = "empires2_x1_p1.dat";
			this._openDatFileDialog.Filter = "(*.dat)|*.dat";
			this._openDatFileDialog.Title = "Load data file to edit...";
			// 
			// _openLangDllDialog
			// 
			this._openLangDllDialog.Filter = "(*.dll)|*.dll";
			this._openLangDllDialog.Multiselect = true;
			this._openLangDllDialog.Title = "Load language DLLs for proper name display...";
			// 
			// _dll3TextBox
			// 
			this._dll3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AoETechTreeTool.Properties.Settings.Default, "_dll3Path", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._dll3TextBox.Location = new System.Drawing.Point(141, 90);
			this._dll3TextBox.Name = "_dll3TextBox";
			this._dll3TextBox.Size = new System.Drawing.Size(364, 20);
			this._dll3TextBox.TabIndex = 11;
			this._dll3TextBox.Text = global::AoETechTreeTool.Properties.Settings.Default._dll3Path;
			// 
			// _dll3CheckBox
			// 
			this._dll3CheckBox.AutoSize = true;
			this._dll3CheckBox.Checked = global::AoETechTreeTool.Properties.Settings.Default._dll3Checked;
			this._dll3CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this._dll3CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AoETechTreeTool.Properties.Settings.Default, "_dll3Checked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._dll3CheckBox.Location = new System.Drawing.Point(120, 93);
			this._dll3CheckBox.Name = "_dll3CheckBox";
			this._dll3CheckBox.Size = new System.Drawing.Size(15, 14);
			this._dll3CheckBox.TabIndex = 10;
			this._dll3CheckBox.UseVisualStyleBackColor = true;
			this._dll3CheckBox.CheckedChanged += new System.EventHandler(this._dll3CheckBox_CheckedChanged);
			// 
			// _dll2TextBox
			// 
			this._dll2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AoETechTreeTool.Properties.Settings.Default, "_dll2Path", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._dll2TextBox.Location = new System.Drawing.Point(141, 64);
			this._dll2TextBox.Name = "_dll2TextBox";
			this._dll2TextBox.Size = new System.Drawing.Size(364, 20);
			this._dll2TextBox.TabIndex = 8;
			this._dll2TextBox.Text = global::AoETechTreeTool.Properties.Settings.Default._dll2Path;
			// 
			// _dll2CheckBox
			// 
			this._dll2CheckBox.AutoSize = true;
			this._dll2CheckBox.Checked = global::AoETechTreeTool.Properties.Settings.Default._dll2Checked;
			this._dll2CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this._dll2CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AoETechTreeTool.Properties.Settings.Default, "_dll2Checked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._dll2CheckBox.Location = new System.Drawing.Point(120, 67);
			this._dll2CheckBox.Name = "_dll2CheckBox";
			this._dll2CheckBox.Size = new System.Drawing.Size(15, 14);
			this._dll2CheckBox.TabIndex = 7;
			this._dll2CheckBox.UseVisualStyleBackColor = true;
			this._dll2CheckBox.CheckedChanged += new System.EventHandler(this._dll2CheckBox_CheckedChanged);
			// 
			// _dll1TextBox
			// 
			this._dll1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AoETechTreeTool.Properties.Settings.Default, "_dll1Path", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._dll1TextBox.Location = new System.Drawing.Point(141, 38);
			this._dll1TextBox.Name = "_dll1TextBox";
			this._dll1TextBox.Size = new System.Drawing.Size(364, 20);
			this._dll1TextBox.TabIndex = 5;
			this._dll1TextBox.Text = global::AoETechTreeTool.Properties.Settings.Default._dll1Path;
			// 
			// _dll1CheckBox
			// 
			this._dll1CheckBox.AutoSize = true;
			this._dll1CheckBox.Checked = global::AoETechTreeTool.Properties.Settings.Default._dll1Checked;
			this._dll1CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this._dll1CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AoETechTreeTool.Properties.Settings.Default, "_dll1Checked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._dll1CheckBox.Location = new System.Drawing.Point(120, 41);
			this._dll1CheckBox.Name = "_dll1CheckBox";
			this._dll1CheckBox.Size = new System.Drawing.Size(15, 14);
			this._dll1CheckBox.TabIndex = 4;
			this._dll1CheckBox.UseVisualStyleBackColor = true;
			this._dll1CheckBox.CheckedChanged += new System.EventHandler(this._dll1CheckBox_CheckedChanged);
			// 
			// _datTextBox
			// 
			this._datTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AoETechTreeTool.Properties.Settings.Default, "_datPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this._datTextBox.Location = new System.Drawing.Point(141, 12);
			this._datTextBox.Name = "_datTextBox";
			this._datTextBox.Size = new System.Drawing.Size(364, 20);
			this._datTextBox.TabIndex = 2;
			this._datTextBox.Text = global::AoETechTreeTool.Properties.Settings.Default._datPath;
			// 
			// PathForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 146);
			this.Controls.Add(this._dll3Button);
			this.Controls.Add(this._dll2Button);
			this.Controls.Add(this._dll1Button);
			this.Controls.Add(this._datButton);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._dll3TextBox);
			this.Controls.Add(this._dll3CheckBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this._dll2TextBox);
			this.Controls.Add(this._dll2CheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this._dll1TextBox);
			this.Controls.Add(this._dll1CheckBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._datTextBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PathForm";
			this.Text = "Age of Empires II: New Tech Tree Editing Tool - Load DAT file ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PathForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Button _datButton;
		private System.Windows.Forms.Button _dll1Button;
		private System.Windows.Forms.Button _dll2Button;
		private System.Windows.Forms.Button _dll3Button;
		private System.Windows.Forms.OpenFileDialog _openDatFileDialog;
		private System.Windows.Forms.OpenFileDialog _openLangDllDialog;
		private System.Windows.Forms.CheckBox _dll1CheckBox;
		private System.Windows.Forms.CheckBox _dll2CheckBox;
		private System.Windows.Forms.CheckBox _dll3CheckBox;
		private System.Windows.Forms.TextBox _datTextBox;
		private System.Windows.Forms.TextBox _dll1TextBox;
		private System.Windows.Forms.TextBox _dll2TextBox;
		private System.Windows.Forms.TextBox _dll3TextBox;
	}
}