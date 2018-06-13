namespace WorkActivityLog
{
    partial class ActivityLogMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityLogMain));
            this.cmbProjectTitle = new System.Windows.Forms.ComboBox();
            this.lblYearMonth = new System.Windows.Forms.Label();
            this.rtbProjectNotes = new System.Windows.Forms.RichTextBox();
            this.cmbProjectStatus = new System.Windows.Forms.ComboBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.ts1 = new System.Windows.Forms.ToolStrip();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbVoid = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbChangeMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbsSort = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.chkPriority = new System.Windows.Forms.CheckBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblDirty = new System.Windows.Forms.Label();
            this.ts1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProjectTitle
            // 
            this.cmbProjectTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjectTitle.FormattingEnabled = true;
            this.cmbProjectTitle.Location = new System.Drawing.Point(80, 80);
            this.cmbProjectTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProjectTitle.Name = "cmbProjectTitle";
            this.cmbProjectTitle.Size = new System.Drawing.Size(488, 24);
            this.cmbProjectTitle.TabIndex = 0;
            this.cmbProjectTitle.SelectedIndexChanged += new System.EventHandler(this.cmbProjectTitle_SelectedIndexChanged);
            this.cmbProjectTitle.Leave += new System.EventHandler(this.cmbProjectTitle_Leave);
            // 
            // lblYearMonth
            // 
            this.lblYearMonth.AutoSize = true;
            this.lblYearMonth.Location = new System.Drawing.Point(80, 56);
            this.lblYearMonth.Name = "lblYearMonth";
            this.lblYearMonth.Size = new System.Drawing.Size(74, 16);
            this.lblYearMonth.TabIndex = 1;
            this.lblYearMonth.Text = "Year Month";
            // 
            // rtbProjectNotes
            // 
            this.rtbProjectNotes.Location = new System.Drawing.Point(80, 184);
            this.rtbProjectNotes.Name = "rtbProjectNotes";
            this.rtbProjectNotes.Size = new System.Drawing.Size(856, 456);
            this.rtbProjectNotes.TabIndex = 6;
            this.rtbProjectNotes.Text = "Project Notes";
            this.rtbProjectNotes.TextChanged += new System.EventHandler(this.rtbProjectNotes_TextChanged);
            // 
            // cmbProjectStatus
            // 
            this.cmbProjectStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjectStatus.FormattingEnabled = true;
            this.cmbProjectStatus.Location = new System.Drawing.Point(688, 80);
            this.cmbProjectStatus.Name = "cmbProjectStatus";
            this.cmbProjectStatus.Size = new System.Drawing.Size(248, 24);
            this.cmbProjectStatus.TabIndex = 3;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(256, 648);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(200, 32);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(552, 648);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(200, 32);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ts1
            // 
            this.ts1.AutoSize = false;
            this.ts1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDelete,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbVoid,
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbChangeMenu,
            this.toolStripSeparator3,
            this.tbsSort});
            this.ts1.Location = new System.Drawing.Point(0, 0);
            this.ts1.Name = "ts1";
            this.ts1.Size = new System.Drawing.Size(1028, 48);
            this.ts1.TabIndex = 10;
            this.ts1.Text = "toolStrip1";
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(25, 25);
            this.tsbDelete.Text = " Delete Entry";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.AutoSize = false;
            this.tsbSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbSave.BackgroundImage")));
            this.tsbSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(25, 25);
            this.tsbSave.Text = "Save";
            this.tsbSave.ToolTipText = "Save Changes To This Entry";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbVoid
            // 
            this.tsbVoid.AutoSize = false;
            this.tsbVoid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbVoid.BackgroundImage")));
            this.tsbVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbVoid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsbVoid.Image = ((System.Drawing.Image)(resources.GetObject("tsbVoid.Image")));
            this.tsbVoid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVoid.Name = "tsbVoid";
            this.tsbVoid.Size = new System.Drawing.Size(25, 25);
            this.tsbVoid.Text = "Void";
            this.tsbVoid.ToolTipText = "Discard Changes Made To This Entry";
            this.tsbVoid.Click += new System.EventHandler(this.tsbVoid_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.AutoSize = false;
            this.tsbNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbNew.BackgroundImage")));
            this.tsbNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(25, 25);
            this.tsbNew.Text = "New Entry";
            this.tsbNew.ToolTipText = "Add New Entry";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbChangeMenu
            // 
            this.tsbChangeMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbChangeMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsbChangeMenu.Image")));
            this.tsbChangeMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChangeMenu.Name = "tsbChangeMenu";
            this.tsbChangeMenu.Size = new System.Drawing.Size(123, 45);
            this.tsbChangeMenu.Text = "Change Log Month";
            this.tsbChangeMenu.ToolTipText = "Change Log To Different Month";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tbsSort
            // 
            this.tbsSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbsSort.Image = ((System.Drawing.Image)(resources.GetObject("tbsSort.Image")));
            this.tbsSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSort.Name = "tbsSort";
            this.tbsSort.Size = new System.Drawing.Size(57, 45);
            this.tbsSort.Text = "Sort By";
            this.tbsSort.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tbsSort_DropDownItemClicked);
            this.tbsSort.Click += new System.EventHandler(this.tbsSort_Click);
            // 
            // chkStatus
            // 
            this.chkStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStatus.Location = new System.Drawing.Point(688, 120);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(248, 20);
            this.chkStatus.TabIndex = 4;
            this.chkStatus.Text = "Status";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // chkPriority
            // 
            this.chkPriority.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPriority.Location = new System.Drawing.Point(688, 152);
            this.chkPriority.Name = "chkPriority";
            this.chkPriority.Size = new System.Drawing.Size(248, 20);
            this.chkPriority.TabIndex = 5;
            this.chkPriority.Text = "Priority";
            this.chkPriority.UseVisualStyleBackColor = true;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(80, 120);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(144, 22);
            this.lblStartDate.TabIndex = 13;
            this.lblStartDate.Text = "Project Start Date: ";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(232, 120);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(160, 22);
            this.txtStartDate.TabIndex = 1;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(232, 152);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(160, 22);
            this.txtEndDate.TabIndex = 2;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(80, 152);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(144, 22);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "Project End Date: ";
            // 
            // lblDirty
            // 
            this.lblDirty.AutoSize = true;
            this.lblDirty.Location = new System.Drawing.Point(56, 184);
            this.lblDirty.Name = "lblDirty";
            this.lblDirty.Size = new System.Drawing.Size(13, 16);
            this.lblDirty.TabIndex = 17;
            this.lblDirty.Text = "*";
            this.lblDirty.Visible = false;
            // 
            // ActivityLogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 692);
            this.Controls.Add(this.lblDirty);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.chkPriority);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.ts1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.cmbProjectStatus);
            this.Controls.Add(this.rtbProjectNotes);
            this.Controls.Add(this.lblYearMonth);
            this.Controls.Add(this.cmbProjectTitle);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ActivityLogMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activity Log";
            this.Load += new System.EventHandler(this.ActivityLogMain_Load);
            this.ts1.ResumeLayout(false);
            this.ts1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProjectTitle;
        private System.Windows.Forms.Label lblYearMonth;
        private System.Windows.Forms.RichTextBox rtbProjectNotes;
        private System.Windows.Forms.ComboBox cmbProjectStatus;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolStrip ts1;
        private System.Windows.Forms.ToolStripButton tsbVoid;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsbChangeMenu;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.CheckBox chkPriority;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tbsSort;
        private System.Windows.Forms.Label lblDirty;
    }
}

