namespace SubtitlesEditor
{
    partial class TimeControl
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLineTimeValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEndSooner = new System.Windows.Forms.Button();
            this.btnLineSooner = new System.Windows.Forms.Button();
            this.btnBeginLater = new System.Windows.Forms.Button();
            this.lbCharsPerSecValue = new System.Windows.Forms.Label();
            this.btnEndLater = new System.Windows.Forms.Button();
            this.tbBeginTime = new System.Windows.Forms.TextBox();
            this.btnBeginSooner = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.btnLineLater = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbLineTimeValue);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnEndSooner);
            this.groupBox1.Controls.Add(this.btnLineSooner);
            this.groupBox1.Controls.Add(this.btnBeginLater);
            this.groupBox1.Controls.Add(this.lbCharsPerSecValue);
            this.groupBox1.Controls.Add(this.btnEndLater);
            this.groupBox1.Controls.Add(this.tbBeginTime);
            this.groupBox1.Controls.Add(this.btnBeginSooner);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbEndTime);
            this.groupBox1.Controls.Add(this.btnLineLater);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(167, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(188, 178);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timing";
            // 
            // lbLineTimeValue
            // 
            this.lbLineTimeValue.AutoSize = true;
            this.lbLineTimeValue.Location = new System.Drawing.Point(121, 130);
            this.lbLineTimeValue.Name = "lbLineTimeValue";
            this.lbLineTimeValue.Size = new System.Drawing.Size(0, 13);
            this.lbLineTimeValue.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(5, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Chars per second:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Line being showed:";
            // 
            // btnEndSooner
            // 
            this.btnEndSooner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEndSooner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEndSooner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEndSooner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndSooner.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEndSooner.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEndSooner.Image = ((System.Drawing.Image)(resources.GetObject("btnEndSooner.Image")));
            this.btnEndSooner.Location = new System.Drawing.Point(80, 77);
            this.btnEndSooner.Name = "btnEndSooner";
            this.btnEndSooner.Size = new System.Drawing.Size(32, 15);
            this.btnEndSooner.TabIndex = 39;
            this.btnEndSooner.Text = "<";
            this.btnEndSooner.UseVisualStyleBackColor = true;
            this.btnEndSooner.Click += new System.EventHandler(this.btnEndSooner_Click);
            // 
            // btnLineSooner
            // 
            this.btnLineSooner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLineSooner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLineSooner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLineSooner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineSooner.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLineSooner.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLineSooner.Image = ((System.Drawing.Image)(resources.GetObject("btnLineSooner.Image")));
            this.btnLineSooner.Location = new System.Drawing.Point(27, 32);
            this.btnLineSooner.Name = "btnLineSooner";
            this.btnLineSooner.Size = new System.Drawing.Size(32, 15);
            this.btnLineSooner.TabIndex = 41;
            this.btnLineSooner.Text = "<";
            this.btnLineSooner.UseVisualStyleBackColor = true;
            this.btnLineSooner.Click += new System.EventHandler(this.btnLineSooner_Click);
            // 
            // btnBeginLater
            // 
            this.btnBeginLater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBeginLater.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBeginLater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBeginLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginLater.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBeginLater.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBeginLater.Image = ((System.Drawing.Image)(resources.GetObject("btnBeginLater.Image")));
            this.btnBeginLater.Location = new System.Drawing.Point(42, 77);
            this.btnBeginLater.Name = "btnBeginLater";
            this.btnBeginLater.Size = new System.Drawing.Size(32, 15);
            this.btnBeginLater.TabIndex = 38;
            this.btnBeginLater.UseVisualStyleBackColor = true;
            this.btnBeginLater.Click += new System.EventHandler(this.btnBeginLater_Click);
            // 
            // lbCharsPerSecValue
            // 
            this.lbCharsPerSecValue.AutoSize = true;
            this.lbCharsPerSecValue.Location = new System.Drawing.Point(121, 105);
            this.lbCharsPerSecValue.Name = "lbCharsPerSecValue";
            this.lbCharsPerSecValue.Size = new System.Drawing.Size(0, 13);
            this.lbCharsPerSecValue.TabIndex = 43;
            // 
            // btnEndLater
            // 
            this.btnEndLater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEndLater.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEndLater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEndLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndLater.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEndLater.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEndLater.Image = ((System.Drawing.Image)(resources.GetObject("btnEndLater.Image")));
            this.btnEndLater.Location = new System.Drawing.Point(118, 76);
            this.btnEndLater.Name = "btnEndLater";
            this.btnEndLater.Size = new System.Drawing.Size(32, 15);
            this.btnEndLater.TabIndex = 40;
            this.btnEndLater.UseVisualStyleBackColor = true;
            this.btnEndLater.Click += new System.EventHandler(this.btnEndLater_Click);
            // 
            // tbBeginTime
            // 
            this.tbBeginTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBeginTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBeginTime.Location = new System.Drawing.Point(4, 53);
            this.tbBeginTime.Name = "tbBeginTime";
            this.tbBeginTime.ReadOnly = true;
            this.tbBeginTime.Size = new System.Drawing.Size(70, 18);
            this.tbBeginTime.TabIndex = 35;
            this.tbBeginTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBeginSooner
            // 
            this.btnBeginSooner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBeginSooner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBeginSooner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBeginSooner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginSooner.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBeginSooner.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBeginSooner.Image = global::SubtitlesEditor.Properties.Resources.backward;
            this.btnBeginSooner.Location = new System.Drawing.Point(4, 77);
            this.btnBeginSooner.Name = "btnBeginSooner";
            this.btnBeginSooner.Size = new System.Drawing.Size(32, 15);
            this.btnBeginSooner.TabIndex = 37;
            this.btnBeginSooner.Text = "<";
            this.btnBeginSooner.UseVisualStyleBackColor = true;
            this.btnBeginSooner.Click += new System.EventHandler(this.btnBeginSooner_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(4, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Line info:";
            // 
            // tbEndTime
            // 
            this.tbEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEndTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbEndTime.Location = new System.Drawing.Point(80, 53);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(69, 18);
            this.tbEndTime.TabIndex = 36;
            this.tbEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLineLater
            // 
            this.btnLineLater.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLineLater.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLineLater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLineLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineLater.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLineLater.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLineLater.Image = ((System.Drawing.Image)(resources.GetObject("btnLineLater.Image")));
            this.btnLineLater.Location = new System.Drawing.Point(100, 32);
            this.btnLineLater.Name = "btnLineLater";
            this.btnLineLater.Size = new System.Drawing.Size(32, 15);
            this.btnLineLater.TabIndex = 42;
            this.btnLineLater.UseVisualStyleBackColor = true;
            this.btnLineLater.Click += new System.EventHandler(this.btnLineLater_Click);
            // 
            // TimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TimeControl";
            this.Size = new System.Drawing.Size(188, 153);
            this.Load += new System.EventHandler(this.TimeControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbLineTimeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEndSooner;
        private System.Windows.Forms.Button btnLineSooner;
        private System.Windows.Forms.Button btnBeginLater;
        private System.Windows.Forms.Label lbCharsPerSecValue;
        private System.Windows.Forms.Button btnEndLater;
        private System.Windows.Forms.TextBox tbBeginTime;
        private System.Windows.Forms.Button btnBeginSooner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.Button btnLineLater;
    }
}
