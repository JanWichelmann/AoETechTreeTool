namespace AoETechTreeTool
{
	partial class MainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this._loadDataButton = new System.Windows.Forms.Button();
			this._saveDataButton = new System.Windows.Forms.Button();
			this._exportTreeButton = new System.Windows.Forms.Button();
			this._importTreeButton = new System.Windows.Forms.Button();
			this._treeGroupBox = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this._entryDownButton = new System.Windows.Forms.Button();
			this._entryUpButton = new System.Windows.Forms.Button();
			this._entryDeleteButton = new System.Windows.Forms.Button();
			this._entryNewButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this._openDatFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._openLangDllDialog = new System.Windows.Forms.OpenFileDialog();
			this._treeGroupBox.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(3, 16);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(609, 528);
			this.treeView1.TabIndex = 0;
			// 
			// _loadDataButton
			// 
			this._loadDataButton.Location = new System.Drawing.Point(16, 13);
			this._loadDataButton.Name = "_loadDataButton";
			this._loadDataButton.Size = new System.Drawing.Size(130, 23);
			this._loadDataButton.TabIndex = 1;
			this._loadDataButton.Text = "Load data file";
			this._loadDataButton.UseVisualStyleBackColor = true;
			this._loadDataButton.Click += new System.EventHandler(this._loadDataButton_Click);
			// 
			// _saveDataButton
			// 
			this._saveDataButton.Enabled = false;
			this._saveDataButton.Location = new System.Drawing.Point(152, 13);
			this._saveDataButton.Name = "_saveDataButton";
			this._saveDataButton.Size = new System.Drawing.Size(130, 23);
			this._saveDataButton.TabIndex = 2;
			this._saveDataButton.Text = "Save data file";
			this._saveDataButton.UseVisualStyleBackColor = true;
			this._saveDataButton.Click += new System.EventHandler(this._saveDataButton_Click);
			// 
			// _exportTreeButton
			// 
			this._exportTreeButton.Enabled = false;
			this._exportTreeButton.Location = new System.Drawing.Point(288, 13);
			this._exportTreeButton.Name = "_exportTreeButton";
			this._exportTreeButton.Size = new System.Drawing.Size(130, 23);
			this._exportTreeButton.TabIndex = 3;
			this._exportTreeButton.Text = "Export tech tree data";
			this._exportTreeButton.UseVisualStyleBackColor = true;
			this._exportTreeButton.Click += new System.EventHandler(this._exportTreeButton_Click);
			// 
			// _importTreeButton
			// 
			this._importTreeButton.Enabled = false;
			this._importTreeButton.Location = new System.Drawing.Point(424, 13);
			this._importTreeButton.Name = "_importTreeButton";
			this._importTreeButton.Size = new System.Drawing.Size(130, 23);
			this._importTreeButton.TabIndex = 4;
			this._importTreeButton.Text = "Import tech tree data";
			this._importTreeButton.UseVisualStyleBackColor = true;
			this._importTreeButton.Click += new System.EventHandler(this._importTreeButton_Click);
			// 
			// _treeGroupBox
			// 
			this._treeGroupBox.Controls.Add(this.treeView1);
			this._treeGroupBox.Controls.Add(this.panel2);
			this._treeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._treeGroupBox.Enabled = false;
			this._treeGroupBox.Location = new System.Drawing.Point(0, 44);
			this._treeGroupBox.Name = "_treeGroupBox";
			this._treeGroupBox.Size = new System.Drawing.Size(852, 547);
			this._treeGroupBox.TabIndex = 5;
			this._treeGroupBox.TabStop = false;
			this._treeGroupBox.Text = "Tech Tree Editing";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this._entryDownButton);
			this.panel2.Controls.Add(this._entryUpButton);
			this.panel2.Controls.Add(this._entryDeleteButton);
			this.panel2.Controls.Add(this._entryNewButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(612, 16);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(237, 528);
			this.panel2.TabIndex = 1;
			// 
			// _entryDownButton
			// 
			this._entryDownButton.Location = new System.Drawing.Point(178, 3);
			this._entryDownButton.Name = "_entryDownButton";
			this._entryDownButton.Size = new System.Drawing.Size(50, 23);
			this._entryDownButton.TabIndex = 3;
			this._entryDownButton.Text = "Down";
			this._entryDownButton.UseVisualStyleBackColor = true;
			this._entryDownButton.Click += new System.EventHandler(this._entryDownButton_Click);
			// 
			// _entryUpButton
			// 
			this._entryUpButton.Location = new System.Drawing.Point(122, 3);
			this._entryUpButton.Name = "_entryUpButton";
			this._entryUpButton.Size = new System.Drawing.Size(50, 23);
			this._entryUpButton.TabIndex = 2;
			this._entryUpButton.Text = "Up";
			this._entryUpButton.UseVisualStyleBackColor = true;
			this._entryUpButton.Click += new System.EventHandler(this._entryUpButton_Click);
			// 
			// _entryDeleteButton
			// 
			this._entryDeleteButton.Location = new System.Drawing.Point(66, 3);
			this._entryDeleteButton.Name = "_entryDeleteButton";
			this._entryDeleteButton.Size = new System.Drawing.Size(50, 23);
			this._entryDeleteButton.TabIndex = 1;
			this._entryDeleteButton.Text = "Delete";
			this._entryDeleteButton.UseVisualStyleBackColor = true;
			this._entryDeleteButton.Click += new System.EventHandler(this._entryDeleteButton_Click);
			// 
			// _entryNewButton
			// 
			this._entryNewButton.Location = new System.Drawing.Point(10, 3);
			this._entryNewButton.Name = "_entryNewButton";
			this._entryNewButton.Size = new System.Drawing.Size(50, 23);
			this._entryNewButton.TabIndex = 0;
			this._entryNewButton.Text = "New";
			this._entryNewButton.UseVisualStyleBackColor = true;
			this._entryNewButton.Click += new System.EventHandler(this._entryNewButton_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this._loadDataButton);
			this.panel1.Controls.Add(this._saveDataButton);
			this.panel1.Controls.Add(this._importTreeButton);
			this.panel1.Controls.Add(this._exportTreeButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(852, 44);
			this.panel1.TabIndex = 6;
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(852, 591);
			this.Controls.Add(this._treeGroupBox);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(600, 200);
			this.Name = "MainForm";
			this.Text = "Age of Empires II: New Tech Tree Editing Tool";
			this._treeGroupBox.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button _loadDataButton;
		private System.Windows.Forms.Button _saveDataButton;
		private System.Windows.Forms.Button _exportTreeButton;
		private System.Windows.Forms.Button _importTreeButton;
		private System.Windows.Forms.GroupBox _treeGroupBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button _entryDownButton;
		private System.Windows.Forms.Button _entryUpButton;
		private System.Windows.Forms.Button _entryDeleteButton;
		private System.Windows.Forms.Button _entryNewButton;
		private System.Windows.Forms.OpenFileDialog _openDatFileDialog;
		private System.Windows.Forms.OpenFileDialog _openLangDllDialog;
	}
}

