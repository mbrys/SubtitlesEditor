namespace SubtitlesEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param fileName="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSubsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbLineText = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbTranslationTimeDisplayed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTranlationCps = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTranslationProperties = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbLineTranslation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOrientation = new System.Windows.Forms.ComboBox();
            this.chbTranslation = new System.Windows.Forms.CheckBox();
            this.btnNextLine = new System.Windows.Forms.Button();
            this.btnPrevLine = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.navigationControl1 = new SubtitlesEditor.Forms.NavigationControl();
            this.timeControl1 = new SubtitlesEditor.TimeControl();
            this.saveTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.edycjaToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSubsToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveTranslationToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSubsToolStripMenuItem
            // 
            this.openSubsToolStripMenuItem.Name = "openSubsToolStripMenuItem";
            this.openSubsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openSubsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openSubsToolStripMenuItem.Text = "Open subs file...";
            this.openSubsToolStripMenuItem.Click += new System.EventHandler(this.openSubsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateTextToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.edycjaToolStripMenuItem.Text = "Edit";
            // 
            // duplicateTextToolStripMenuItem
            // 
            this.duplicateTextToolStripMenuItem.Enabled = false;
            this.duplicateTextToolStripMenuItem.Name = "duplicateTextToolStripMenuItem";
            this.duplicateTextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateTextToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.duplicateTextToolStripMenuItem.Text = "Duplicate text";
            this.duplicateTextToolStripMenuItem.Click += new System.EventHandler(this.duplicateTextToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseEncodingToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // chooseEncodingToolStripMenuItem
            // 
            this.chooseEncodingToolStripMenuItem.Name = "chooseEncodingToolStripMenuItem";
            this.chooseEncodingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.chooseEncodingToolStripMenuItem.Text = "Choose encoding...";
            this.chooseEncodingToolStripMenuItem.Click += new System.EventHandler(this.chooseEncodingToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Subtitles|*.srt; *.sub; *.txt; |All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SRT subtitles|*.srt|MicroDVD | *.sub |Mpl2 subtitles|*.txt|All files|*.*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Location = new System.Drawing.Point(0, 151);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(622, 295);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.timeControl1);
            this.splitContainer1.Panel1.Controls.Add(this.tbLineText);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.tbLineTranslation);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(622, 305);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 1;
            // 
            // tbLineText
            // 
            this.tbLineText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLineText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLineText.Location = new System.Drawing.Point(3, 3);
            this.tbLineText.Multiline = true;
            this.tbLineText.Name = "tbLineText";
            this.tbLineText.Size = new System.Drawing.Size(427, 299);
            this.tbLineText.TabIndex = 0;
            this.tbLineText.TextChanged += new System.EventHandler(this.tbLineText_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lbTranslationTimeDisplayed);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lbTranlationCps);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lbTranslationProperties);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox4.Location = new System.Drawing.Point(963, 3);
            this.groupBox4.MaximumSize = new System.Drawing.Size(167, 178);
            this.groupBox4.MinimumSize = new System.Drawing.Size(167, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox4.Size = new System.Drawing.Size(167, 178);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Timing";
            // 
            // lbTranslationTimeDisplayed
            // 
            this.lbTranslationTimeDisplayed.AutoSize = true;
            this.lbTranslationTimeDisplayed.Location = new System.Drawing.Point(133, 86);
            this.lbTranslationTimeDisplayed.Name = "lbTranslationTimeDisplayed";
            this.lbTranslationTimeDisplayed.Size = new System.Drawing.Size(0, 13);
            this.lbTranslationTimeDisplayed.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Line being showed:";
            // 
            // lbTranlationCps
            // 
            this.lbTranlationCps.AutoSize = true;
            this.lbTranlationCps.Location = new System.Drawing.Point(133, 61);
            this.lbTranlationCps.Name = "lbTranlationCps";
            this.lbTranlationCps.Size = new System.Drawing.Size(0, 13);
            this.lbTranlationCps.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(4, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chars per second:";
            // 
            // lbTranslationProperties
            // 
            this.lbTranslationProperties.AutoSize = true;
            this.lbTranslationProperties.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTranslationProperties.Location = new System.Drawing.Point(4, 24);
            this.lbTranslationProperties.Name = "lbTranslationProperties";
            this.lbTranslationProperties.Size = new System.Drawing.Size(55, 13);
            this.lbTranslationProperties.TabIndex = 14;
            this.lbTranslationProperties.Text = "Line info:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(83, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(69, 18);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(7, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(70, 18);
            this.textBox2.TabIndex = 17;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLineTranslation
            // 
            this.tbLineTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLineTranslation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLineTranslation.Location = new System.Drawing.Point(3, 3);
            this.tbLineTranslation.Multiline = true;
            this.tbLineTranslation.Name = "tbLineTranslation";
            this.tbLineTranslation.ReadOnly = true;
            this.tbLineTranslation.Size = new System.Drawing.Size(466, 226);
            this.tbLineTranslation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Panes orientation:";
            // 
            // cmbOrientation
            // 
            this.cmbOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrientation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOrientation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbOrientation.FormattingEnabled = true;
            this.cmbOrientation.Location = new System.Drawing.Point(124, 29);
            this.cmbOrientation.Name = "cmbOrientation";
            this.cmbOrientation.Size = new System.Drawing.Size(121, 21);
            this.cmbOrientation.TabIndex = 21;
            this.cmbOrientation.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // chbTranslation
            // 
            this.chbTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbTranslation.AutoSize = true;
            this.chbTranslation.Cursor = System.Windows.Forms.Cursors.Default;
            this.chbTranslation.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chbTranslation.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chbTranslation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.chbTranslation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chbTranslation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbTranslation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbTranslation.Location = new System.Drawing.Point(258, 33);
            this.chbTranslation.Name = "chbTranslation";
            this.chbTranslation.Size = new System.Drawing.Size(80, 17);
            this.chbTranslation.TabIndex = 20;
            this.chbTranslation.Text = "Translation";
            this.chbTranslation.UseVisualStyleBackColor = true;
            this.chbTranslation.CheckedChanged += new System.EventHandler(this.chbTranslation_CheckedChanged);
            // 
            // btnNextLine
            // 
            this.btnNextLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextLine.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnNextLine.Enabled = false;
            this.btnNextLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNextLine.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNextLine.Location = new System.Drawing.Point(534, 462);
            this.btnNextLine.MaximumSize = new System.Drawing.Size(75, 23);
            this.btnNextLine.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnNextLine.Name = "btnNextLine";
            this.btnNextLine.Size = new System.Drawing.Size(75, 23);
            this.btnNextLine.TabIndex = 13;
            this.btnNextLine.Text = "Next line";
            this.btnNextLine.UseVisualStyleBackColor = false;
            this.btnNextLine.Click += new System.EventHandler(this.btnNextLine_Click);
            // 
            // btnPrevLine
            // 
            this.btnPrevLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevLine.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnPrevLine.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrevLine.Enabled = false;
            this.btnPrevLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevLine.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrevLine.Location = new System.Drawing.Point(16, 462);
            this.btnPrevLine.MaximumSize = new System.Drawing.Size(75, 23);
            this.btnPrevLine.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnPrevLine.Name = "btnPrevLine";
            this.btnPrevLine.Size = new System.Drawing.Size(75, 23);
            this.btnPrevLine.TabIndex = 12;
            this.btnPrevLine.Text = "Previous line";
            this.btnPrevLine.UseVisualStyleBackColor = false;
            this.btnPrevLine.Click += new System.EventHandler(this.btnPrevLine_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbOrientation);
            this.groupBox2.Controls.Add(this.chbTranslation);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(256, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 62);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // navigationControl1
            // 
            this.navigationControl1.Location = new System.Drawing.Point(12, 29);
            this.navigationControl1.Name = "navigationControl1";
            this.navigationControl1.Size = new System.Drawing.Size(234, 62);
            this.navigationControl1.TabIndex = 26;
            // 
            // timeControl1
            // 
            this.timeControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeControl1.LineInfo = null;
            this.timeControl1.Location = new System.Drawing.Point(436, 5);
            this.timeControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.SecsToMove = 0.2D;
            this.timeControl1.Size = new System.Drawing.Size(174, 186);
            this.timeControl1.TabIndex = 26;
            // 
            // saveTranslationToolStripMenuItem
            // 
            this.saveTranslationToolStripMenuItem.Name = "saveTranslationToolStripMenuItem";
            this.saveTranslationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveTranslationToolStripMenuItem.Text = "Save translation";
            this.saveTranslationToolStripMenuItem.Click += new System.EventHandler(this.saveTranslationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnNextLine;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnPrevLine;
            this.ClientSize = new System.Drawing.Size(622, 501);
            this.Controls.Add(this.navigationControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnNextLine);
            this.Controls.Add(this.btnPrevLine);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(638, 344);
            this.Name = "MainForm";
            this.Text = "Subtitles Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSubsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnNextLine;
        private System.Windows.Forms.Button btnPrevLine;
        private System.Windows.Forms.TextBox tbLineText;
        private System.Windows.Forms.CheckBox chbTranslation;
        private System.Windows.Forms.TextBox tbLineTranslation;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateTextToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOrientation;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem chooseEncodingToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbTranslationTimeDisplayed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTranlationCps;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTranslationProperties;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Forms.NavigationControl navigationControl1;
        private TimeControl timeControl1;
        private System.Windows.Forms.ToolStripMenuItem saveTranslationToolStripMenuItem;
    }
}

