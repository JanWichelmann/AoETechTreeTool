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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this._treeView = new System.Windows.Forms.TreeView();
			this._loadDataButton = new System.Windows.Forms.Button();
			this._saveDataButton = new System.Windows.Forms.Button();
			this._exportTreeButton = new System.Windows.Forms.Button();
			this._importTreeButton = new System.Windows.Forms.Button();
			this._treeGroupBox = new System.Windows.Forms.GroupBox();
			this._editPanel = new System.Windows.Forms.Panel();
			this._requirementsGroupBox = new System.Windows.Forms.GroupBox();
			this._requirementsView = new System.Windows.Forms.DataGridView();
			this._requirementsViewTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this._requirementsViewIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._civsGroupBox = new System.Windows.Forms.GroupBox();
			this._civsInvertButton = new System.Windows.Forms.Button();
			this._civsNoneButton = new System.Windows.Forms.Button();
			this._civsAllButton = new System.Windows.Forms.Button();
			this._civsList = new System.Windows.Forms.CheckedListBox();
			this._renderModeGroupBox = new System.Windows.Forms.GroupBox();
			this._renderModeHideButton = new System.Windows.Forms.RadioButton();
			this._renderModeStandardButton = new System.Windows.Forms.RadioButton();
			this._idField = new System.Windows.Forms.NumericUpDown();
			this._ageField = new System.Windows.Forms.NumericUpDown();
			this._ageLabel = new System.Windows.Forms.Label();
			this._idLabel = new System.Windows.Forms.Label();
			this._elementTypeGroupBox = new System.Windows.Forms.GroupBox();
			this._typeUnitButton = new System.Windows.Forms.RadioButton();
			this._typeResearchButton = new System.Windows.Forms.RadioButton();
			this._typeBuildingButton = new System.Windows.Forms.RadioButton();
			this._entryDownButton = new System.Windows.Forms.Button();
			this._entryUpButton = new System.Windows.Forms.Button();
			this._entryDeleteButton = new System.Windows.Forms.Button();
			this._entryNewButton = new System.Windows.Forms.Button();
			this._menuPanel = new System.Windows.Forms.Panel();
			this._saveDatFileDialog = new System.Windows.Forms.SaveFileDialog();
			this._openTechTreeDialog = new System.Windows.Forms.OpenFileDialog();
			this._saveTechTreeDialog = new System.Windows.Forms.SaveFileDialog();
			this._entryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._entryNewChildMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this._entryNewAboveMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this._entryContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this._entryCopyMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this._entryPasteAsChildMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this._entryPasteAboveMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this._entryContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this._entryDeleteMenuButton = new System.Windows.Forms.ToolStripMenuItem();
			this._treeGroupBox.SuspendLayout();
			this._editPanel.SuspendLayout();
			this._requirementsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._requirementsView)).BeginInit();
			this._civsGroupBox.SuspendLayout();
			this._renderModeGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._idField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._ageField)).BeginInit();
			this._elementTypeGroupBox.SuspendLayout();
			this._menuPanel.SuspendLayout();
			this._entryContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// _treeView
			// 
			this._treeView.AllowDrop = true;
			this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._treeView.Location = new System.Drawing.Point(3, 16);
			this._treeView.Name = "_treeView";
			this._treeView.Size = new System.Drawing.Size(726, 614);
			this._treeView.TabIndex = 0;
			this._treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this._treeView_AfterCollapse);
			this._treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this._treeView_AfterExpand);
			this._treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this._treeView_ItemDrag);
			this._treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._treeView_AfterSelect);
			this._treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this._treeView_DragDrop);
			this._treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this._treeView_DragEnter);
			this._treeView.DragOver += new System.Windows.Forms.DragEventHandler(this._treeView_DragOver);
			this._treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this._treeView_KeyDown);
			this._treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this._treeView_MouseClick);
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
			this._treeGroupBox.Controls.Add(this._treeView);
			this._treeGroupBox.Controls.Add(this._editPanel);
			this._treeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._treeGroupBox.Enabled = false;
			this._treeGroupBox.Location = new System.Drawing.Point(0, 44);
			this._treeGroupBox.Name = "_treeGroupBox";
			this._treeGroupBox.Size = new System.Drawing.Size(969, 633);
			this._treeGroupBox.TabIndex = 5;
			this._treeGroupBox.TabStop = false;
			this._treeGroupBox.Text = "Tech Tree Editing";
			// 
			// _editPanel
			// 
			this._editPanel.Controls.Add(this._requirementsGroupBox);
			this._editPanel.Controls.Add(this._civsGroupBox);
			this._editPanel.Controls.Add(this._renderModeGroupBox);
			this._editPanel.Controls.Add(this._idField);
			this._editPanel.Controls.Add(this._ageField);
			this._editPanel.Controls.Add(this._ageLabel);
			this._editPanel.Controls.Add(this._idLabel);
			this._editPanel.Controls.Add(this._elementTypeGroupBox);
			this._editPanel.Controls.Add(this._entryDownButton);
			this._editPanel.Controls.Add(this._entryUpButton);
			this._editPanel.Controls.Add(this._entryDeleteButton);
			this._editPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this._editPanel.Enabled = false;
			this._editPanel.Location = new System.Drawing.Point(729, 16);
			this._editPanel.Name = "_editPanel";
			this._editPanel.Size = new System.Drawing.Size(237, 614);
			this._editPanel.TabIndex = 1;
			// 
			// _requirementsGroupBox
			// 
			this._requirementsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this._requirementsGroupBox.Controls.Add(this._requirementsView);
			this._requirementsGroupBox.Location = new System.Drawing.Point(10, 525);
			this._requirementsGroupBox.Name = "_requirementsGroupBox";
			this._requirementsGroupBox.Size = new System.Drawing.Size(218, 80);
			this._requirementsGroupBox.TabIndex = 16;
			this._requirementsGroupBox.TabStop = false;
			this._requirementsGroupBox.Text = "Requirements";
			// 
			// _requirementsView
			// 
			this._requirementsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._requirementsView.ColumnHeadersVisible = false;
			this._requirementsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._requirementsViewTypeColumn,
            this._requirementsViewIdColumn});
			this._requirementsView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._requirementsView.Location = new System.Drawing.Point(3, 16);
			this._requirementsView.Name = "_requirementsView";
			this._requirementsView.Size = new System.Drawing.Size(212, 61);
			this._requirementsView.TabIndex = 0;
			this._requirementsView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._requirementsView_CellEndEdit);
			this._requirementsView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this._requirementsView_RowsRemoved);
			// 
			// _requirementsViewTypeColumn
			// 
			this._requirementsViewTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this._requirementsViewTypeColumn.FillWeight = 70F;
			this._requirementsViewTypeColumn.HeaderText = "Type";
			this._requirementsViewTypeColumn.Name = "_requirementsViewTypeColumn";
			// 
			// _requirementsViewIdColumn
			// 
			this._requirementsViewIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this._requirementsViewIdColumn.FillWeight = 30F;
			this._requirementsViewIdColumn.HeaderText = "ID";
			this._requirementsViewIdColumn.Name = "_requirementsViewIdColumn";
			// 
			// _civsGroupBox
			// 
			this._civsGroupBox.Controls.Add(this._civsInvertButton);
			this._civsGroupBox.Controls.Add(this._civsNoneButton);
			this._civsGroupBox.Controls.Add(this._civsAllButton);
			this._civsGroupBox.Controls.Add(this._civsList);
			this._civsGroupBox.Location = new System.Drawing.Point(10, 192);
			this._civsGroupBox.Name = "_civsGroupBox";
			this._civsGroupBox.Size = new System.Drawing.Size(218, 327);
			this._civsGroupBox.TabIndex = 15;
			this._civsGroupBox.TabStop = false;
			this._civsGroupBox.Text = "Civs with access to this item";
			// 
			// _civsInvertButton
			// 
			this._civsInvertButton.Location = new System.Drawing.Point(155, 21);
			this._civsInvertButton.Name = "_civsInvertButton";
			this._civsInvertButton.Size = new System.Drawing.Size(60, 23);
			this._civsInvertButton.TabIndex = 3;
			this._civsInvertButton.Text = "invert";
			this._civsInvertButton.UseVisualStyleBackColor = true;
			this._civsInvertButton.Click += new System.EventHandler(this._civsInvertButton_Click);
			// 
			// _civsNoneButton
			// 
			this._civsNoneButton.Location = new System.Drawing.Point(80, 21);
			this._civsNoneButton.Name = "_civsNoneButton";
			this._civsNoneButton.Size = new System.Drawing.Size(60, 23);
			this._civsNoneButton.TabIndex = 2;
			this._civsNoneButton.Text = "none";
			this._civsNoneButton.UseVisualStyleBackColor = true;
			this._civsNoneButton.Click += new System.EventHandler(this._civsNoneButton_Click);
			// 
			// _civsAllButton
			// 
			this._civsAllButton.Location = new System.Drawing.Point(3, 21);
			this._civsAllButton.Name = "_civsAllButton";
			this._civsAllButton.Size = new System.Drawing.Size(60, 23);
			this._civsAllButton.TabIndex = 1;
			this._civsAllButton.Text = "all";
			this._civsAllButton.UseVisualStyleBackColor = true;
			this._civsAllButton.Click += new System.EventHandler(this._civsAllButton_Click);
			// 
			// _civsList
			// 
			this._civsList.CheckOnClick = true;
			this._civsList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._civsList.FormattingEnabled = true;
			this._civsList.Location = new System.Drawing.Point(3, 50);
			this._civsList.Name = "_civsList";
			this._civsList.Size = new System.Drawing.Size(212, 274);
			this._civsList.Sorted = true;
			this._civsList.TabIndex = 0;
			this._civsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._civsList_ItemCheck);
			// 
			// _renderModeGroupBox
			// 
			this._renderModeGroupBox.Controls.Add(this._renderModeHideButton);
			this._renderModeGroupBox.Controls.Add(this._renderModeStandardButton);
			this._renderModeGroupBox.Location = new System.Drawing.Point(10, 119);
			this._renderModeGroupBox.Name = "_renderModeGroupBox";
			this._renderModeGroupBox.Size = new System.Drawing.Size(218, 67);
			this._renderModeGroupBox.TabIndex = 13;
			this._renderModeGroupBox.TabStop = false;
			this._renderModeGroupBox.Text = "Render Mode";
			// 
			// _renderModeHideButton
			// 
			this._renderModeHideButton.AutoSize = true;
			this._renderModeHideButton.Location = new System.Drawing.Point(8, 42);
			this._renderModeHideButton.Name = "_renderModeHideButton";
			this._renderModeHideButton.Size = new System.Drawing.Size(97, 17);
			this._renderModeHideButton.TabIndex = 14;
			this._renderModeHideButton.TabStop = true;
			this._renderModeHideButton.Text = "Hide if disabled";
			this._renderModeHideButton.UseVisualStyleBackColor = true;
			this._renderModeHideButton.CheckedChanged += new System.EventHandler(this._renderModeHideButton_CheckedChanged);
			// 
			// _renderModeStandardButton
			// 
			this._renderModeStandardButton.AutoSize = true;
			this._renderModeStandardButton.Location = new System.Drawing.Point(8, 19);
			this._renderModeStandardButton.Name = "_renderModeStandardButton";
			this._renderModeStandardButton.Size = new System.Drawing.Size(165, 17);
			this._renderModeStandardButton.TabIndex = 14;
			this._renderModeStandardButton.TabStop = true;
			this._renderModeStandardButton.Text = "Standard (grey out if disabled)";
			this._renderModeStandardButton.UseVisualStyleBackColor = true;
			this._renderModeStandardButton.CheckedChanged += new System.EventHandler(this._renderModeStandardButton_CheckedChanged);
			// 
			// _idField
			// 
			this._idField.Location = new System.Drawing.Point(42, 93);
			this._idField.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
			this._idField.Name = "_idField";
			this._idField.Size = new System.Drawing.Size(59, 20);
			this._idField.TabIndex = 10;
			this._idField.ValueChanged += new System.EventHandler(this._idField_ValueChanged);
			// 
			// _ageField
			// 
			this._ageField.Location = new System.Drawing.Point(169, 93);
			this._ageField.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this._ageField.Name = "_ageField";
			this._ageField.Size = new System.Drawing.Size(59, 20);
			this._ageField.TabIndex = 11;
			this._ageField.ValueChanged += new System.EventHandler(this._ageField_ValueChanged);
			// 
			// _ageLabel
			// 
			this._ageLabel.AutoSize = true;
			this._ageLabel.Location = new System.Drawing.Point(134, 96);
			this._ageLabel.Name = "_ageLabel";
			this._ageLabel.Size = new System.Drawing.Size(29, 13);
			this._ageLabel.TabIndex = 10;
			this._ageLabel.Text = "Age:";
			// 
			// _idLabel
			// 
			this._idLabel.AutoSize = true;
			this._idLabel.Location = new System.Drawing.Point(15, 96);
			this._idLabel.Name = "_idLabel";
			this._idLabel.Size = new System.Drawing.Size(21, 13);
			this._idLabel.TabIndex = 8;
			this._idLabel.Text = "ID:";
			// 
			// _elementTypeGroupBox
			// 
			this._elementTypeGroupBox.Controls.Add(this._typeUnitButton);
			this._elementTypeGroupBox.Controls.Add(this._typeResearchButton);
			this._elementTypeGroupBox.Controls.Add(this._typeBuildingButton);
			this._elementTypeGroupBox.Location = new System.Drawing.Point(10, 32);
			this._elementTypeGroupBox.Name = "_elementTypeGroupBox";
			this._elementTypeGroupBox.Size = new System.Drawing.Size(218, 49);
			this._elementTypeGroupBox.TabIndex = 7;
			this._elementTypeGroupBox.TabStop = false;
			this._elementTypeGroupBox.Text = "Type";
			// 
			// _typeUnitButton
			// 
			this._typeUnitButton.AutoSize = true;
			this._typeUnitButton.Checked = true;
			this._typeUnitButton.Location = new System.Drawing.Point(8, 19);
			this._typeUnitButton.Name = "_typeUnitButton";
			this._typeUnitButton.Size = new System.Drawing.Size(44, 17);
			this._typeUnitButton.TabIndex = 4;
			this._typeUnitButton.TabStop = true;
			this._typeUnitButton.Text = "Unit";
			this._typeUnitButton.UseVisualStyleBackColor = true;
			this._typeUnitButton.CheckedChanged += new System.EventHandler(this._typeUnitButton_CheckedChanged);
			// 
			// _typeResearchButton
			// 
			this._typeResearchButton.AutoSize = true;
			this._typeResearchButton.Location = new System.Drawing.Point(141, 19);
			this._typeResearchButton.Name = "_typeResearchButton";
			this._typeResearchButton.Size = new System.Drawing.Size(71, 17);
			this._typeResearchButton.TabIndex = 6;
			this._typeResearchButton.Text = "Research";
			this._typeResearchButton.UseVisualStyleBackColor = true;
			this._typeResearchButton.CheckedChanged += new System.EventHandler(this._typeResearchButton_CheckedChanged);
			// 
			// _typeBuildingButton
			// 
			this._typeBuildingButton.AutoSize = true;
			this._typeBuildingButton.Location = new System.Drawing.Point(64, 19);
			this._typeBuildingButton.Name = "_typeBuildingButton";
			this._typeBuildingButton.Size = new System.Drawing.Size(62, 17);
			this._typeBuildingButton.TabIndex = 5;
			this._typeBuildingButton.Text = "Building";
			this._typeBuildingButton.UseVisualStyleBackColor = true;
			this._typeBuildingButton.CheckedChanged += new System.EventHandler(this._typeBuildingButton_CheckedChanged);
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
			this._entryNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._entryNewButton.Enabled = false;
			this._entryNewButton.Location = new System.Drawing.Point(739, 63);
			this._entryNewButton.Name = "_entryNewButton";
			this._entryNewButton.Size = new System.Drawing.Size(50, 23);
			this._entryNewButton.TabIndex = 0;
			this._entryNewButton.Text = "New";
			this._entryNewButton.UseVisualStyleBackColor = true;
			this._entryNewButton.Click += new System.EventHandler(this._entryNewButton_Click);
			// 
			// _menuPanel
			// 
			this._menuPanel.Controls.Add(this._loadDataButton);
			this._menuPanel.Controls.Add(this._saveDataButton);
			this._menuPanel.Controls.Add(this._importTreeButton);
			this._menuPanel.Controls.Add(this._exportTreeButton);
			this._menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._menuPanel.Location = new System.Drawing.Point(0, 0);
			this._menuPanel.Name = "_menuPanel";
			this._menuPanel.Size = new System.Drawing.Size(969, 44);
			this._menuPanel.TabIndex = 6;
			// 
			// _saveDatFileDialog
			// 
			this._saveDatFileDialog.Filter = "(*.dat)|*.dat";
			this._saveDatFileDialog.Title = "Specify data file save location...";
			// 
			// _openTechTreeDialog
			// 
			this._openTechTreeDialog.Filter = "(*.ntt)|*.ntt";
			this._openTechTreeDialog.Title = "Specify tech tree file to import";
			// 
			// _saveTechTreeDialog
			// 
			this._saveTechTreeDialog.Filter = "(*.ntt)|*.ntt";
			this._saveTechTreeDialog.Title = "Specify exported tech tree destination file...";
			// 
			// _entryContextMenu
			// 
			this._entryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._entryNewChildMenuButton,
            this._entryNewAboveMenuButton,
            this._entryContextMenuSeparator1,
            this._entryCopyMenuButton,
            this._entryPasteAsChildMenuButton,
            this._entryPasteAboveMenuButton,
            this._entryContextMenuSeparator2,
            this._entryDeleteMenuButton});
			this._entryContextMenu.Name = "_entryContextMenu";
			this._entryContextMenu.Size = new System.Drawing.Size(294, 148);
			// 
			// _entryNewChildMenuButton
			// 
			this._entryNewChildMenuButton.Name = "_entryNewChildMenuButton";
			this._entryNewChildMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this._entryNewChildMenuButton.Size = new System.Drawing.Size(293, 22);
			this._entryNewChildMenuButton.Text = "New Child";
			this._entryNewChildMenuButton.Click += new System.EventHandler(this._entryNewChildMenuButton_Click);
			// 
			// _entryNewAboveMenuButton
			// 
			this._entryNewAboveMenuButton.Name = "_entryNewAboveMenuButton";
			this._entryNewAboveMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this._entryNewAboveMenuButton.Size = new System.Drawing.Size(293, 22);
			this._entryNewAboveMenuButton.Text = "New Entry Above";
			this._entryNewAboveMenuButton.Click += new System.EventHandler(this._entryNewAboveMenuButton_Click);
			// 
			// _entryContextMenuSeparator1
			// 
			this._entryContextMenuSeparator1.Name = "_entryContextMenuSeparator1";
			this._entryContextMenuSeparator1.Size = new System.Drawing.Size(290, 6);
			// 
			// _entryCopyMenuButton
			// 
			this._entryCopyMenuButton.Name = "_entryCopyMenuButton";
			this._entryCopyMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this._entryCopyMenuButton.Size = new System.Drawing.Size(293, 22);
			this._entryCopyMenuButton.Text = "Copy";
			this._entryCopyMenuButton.Click += new System.EventHandler(this._entryCopyMenuButton_Click);
			// 
			// _entryPasteAsChildMenuButton
			// 
			this._entryPasteAsChildMenuButton.Name = "_entryPasteAsChildMenuButton";
			this._entryPasteAsChildMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this._entryPasteAsChildMenuButton.Size = new System.Drawing.Size(293, 22);
			this._entryPasteAsChildMenuButton.Text = "Paste As Child";
			this._entryPasteAsChildMenuButton.Click += new System.EventHandler(this._entryPasteAsChildMenuButton_Click);
			// 
			// _entryPasteAboveMenuButton
			// 
			this._entryPasteAboveMenuButton.Name = "_entryPasteAboveMenuButton";
			this._entryPasteAboveMenuButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
			this._entryPasteAboveMenuButton.Size = new System.Drawing.Size(293, 22);
			this._entryPasteAboveMenuButton.Text = "Paste Above";
			this._entryPasteAboveMenuButton.Click += new System.EventHandler(this._entryPasteAboveMenuButton_Click);
			// 
			// _entryContextMenuSeparator2
			// 
			this._entryContextMenuSeparator2.Name = "_entryContextMenuSeparator2";
			this._entryContextMenuSeparator2.Size = new System.Drawing.Size(290, 6);
			// 
			// _entryDeleteMenuButton
			// 
			this._entryDeleteMenuButton.Name = "_entryDeleteMenuButton";
			this._entryDeleteMenuButton.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this._entryDeleteMenuButton.Size = new System.Drawing.Size(293, 22);
			this._entryDeleteMenuButton.Text = "Delete";
			this._entryDeleteMenuButton.Click += new System.EventHandler(this._entryDeleteMenuButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(969, 677);
			this.Controls.Add(this._entryNewButton);
			this.Controls.Add(this._treeGroupBox);
			this.Controls.Add(this._menuPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(600, 700);
			this.Name = "MainForm";
			this.Text = "Age of Empires II: New Tech Tree Editing Tool";
			this._treeGroupBox.ResumeLayout(false);
			this._editPanel.ResumeLayout(false);
			this._editPanel.PerformLayout();
			this._requirementsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._requirementsView)).EndInit();
			this._civsGroupBox.ResumeLayout(false);
			this._renderModeGroupBox.ResumeLayout(false);
			this._renderModeGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._idField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._ageField)).EndInit();
			this._elementTypeGroupBox.ResumeLayout(false);
			this._elementTypeGroupBox.PerformLayout();
			this._menuPanel.ResumeLayout(false);
			this._entryContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView _treeView;
		private System.Windows.Forms.Button _loadDataButton;
		private System.Windows.Forms.Button _saveDataButton;
		private System.Windows.Forms.Button _exportTreeButton;
		private System.Windows.Forms.Button _importTreeButton;
		private System.Windows.Forms.GroupBox _treeGroupBox;
		private System.Windows.Forms.Panel _menuPanel;
		private System.Windows.Forms.Panel _editPanel;
		private System.Windows.Forms.Button _entryDownButton;
		private System.Windows.Forms.Button _entryUpButton;
		private System.Windows.Forms.Button _entryDeleteButton;
		private System.Windows.Forms.Button _entryNewButton;
		private System.Windows.Forms.SaveFileDialog _saveDatFileDialog;
		private System.Windows.Forms.OpenFileDialog _openTechTreeDialog;
		private System.Windows.Forms.SaveFileDialog _saveTechTreeDialog;
		private System.Windows.Forms.RadioButton _typeResearchButton;
		private System.Windows.Forms.RadioButton _typeBuildingButton;
		private System.Windows.Forms.RadioButton _typeUnitButton;
		private System.Windows.Forms.GroupBox _elementTypeGroupBox;
		private System.Windows.Forms.Label _ageLabel;
		private System.Windows.Forms.Label _idLabel;
		private System.Windows.Forms.NumericUpDown _ageField;
		private System.Windows.Forms.NumericUpDown _idField;
		private System.Windows.Forms.GroupBox _renderModeGroupBox;
		private System.Windows.Forms.RadioButton _renderModeStandardButton;
		private System.Windows.Forms.RadioButton _renderModeHideButton;
		private System.Windows.Forms.GroupBox _civsGroupBox;
		private System.Windows.Forms.CheckedListBox _civsList;
		private System.Windows.Forms.Button _civsInvertButton;
		private System.Windows.Forms.Button _civsNoneButton;
		private System.Windows.Forms.Button _civsAllButton;
		private System.Windows.Forms.GroupBox _requirementsGroupBox;
		private System.Windows.Forms.DataGridView _requirementsView;
		private System.Windows.Forms.DataGridViewComboBoxColumn _requirementsViewTypeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn _requirementsViewIdColumn;
		private System.Windows.Forms.ContextMenuStrip _entryContextMenu;
		private System.Windows.Forms.ToolStripMenuItem _entryNewChildMenuButton;
		private System.Windows.Forms.ToolStripMenuItem _entryNewAboveMenuButton;
		private System.Windows.Forms.ToolStripSeparator _entryContextMenuSeparator1;
		private System.Windows.Forms.ToolStripMenuItem _entryCopyMenuButton;
		private System.Windows.Forms.ToolStripMenuItem _entryPasteAsChildMenuButton;
		private System.Windows.Forms.ToolStripMenuItem _entryPasteAboveMenuButton;
		private System.Windows.Forms.ToolStripSeparator _entryContextMenuSeparator2;
		private System.Windows.Forms.ToolStripMenuItem _entryDeleteMenuButton;
	}
}

