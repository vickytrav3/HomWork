namespace Csom_WinFormsApp
{
    partial class CsomPrac
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
            this.lblSiteTitle = new System.Windows.Forms.Label();
            this.txtSiteTitleChange = new System.Windows.Forms.TextBox();
            this.btnTitleSave = new System.Windows.Forms.Button();
            this.SPListsBox = new System.Windows.Forms.ListBox();
            this.dtGridListItems = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridListItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSiteTitle
            // 
            this.lblSiteTitle.AutoSize = true;
            this.lblSiteTitle.Font = new System.Drawing.Font("Lucida Handwriting", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiteTitle.ForeColor = System.Drawing.Color.Red;
            this.lblSiteTitle.Location = new System.Drawing.Point(33, 23);
            this.lblSiteTitle.Name = "lblSiteTitle";
            this.lblSiteTitle.Size = new System.Drawing.Size(304, 57);
            this.lblSiteTitle.TabIndex = 0;
            this.lblSiteTitle.Text = "lblSiteTitle";
            this.lblSiteTitle.Click += new System.EventHandler(this.lblSiteTitle_Click);
            // 
            // txtSiteTitleChange
            // 
            this.txtSiteTitleChange.Location = new System.Drawing.Point(43, 34);
            this.txtSiteTitleChange.Name = "txtSiteTitleChange";
            this.txtSiteTitleChange.Size = new System.Drawing.Size(181, 22);
            this.txtSiteTitleChange.TabIndex = 1;
            this.txtSiteTitleChange.Visible = false;
            // 
            // btnTitleSave
            // 
            this.btnTitleSave.Location = new System.Drawing.Point(231, 34);
            this.btnTitleSave.Name = "btnTitleSave";
            this.btnTitleSave.Size = new System.Drawing.Size(62, 23);
            this.btnTitleSave.TabIndex = 2;
            this.btnTitleSave.Text = "Save";
            this.btnTitleSave.UseVisualStyleBackColor = true;
            this.btnTitleSave.Visible = false;
            this.btnTitleSave.Click += new System.EventHandler(this.btnTitleSave_Click);
            // 
            // SPListsBox
            // 
            this.SPListsBox.FormattingEnabled = true;
            this.SPListsBox.ItemHeight = 16;
            this.SPListsBox.Location = new System.Drawing.Point(43, 83);
            this.SPListsBox.Name = "SPListsBox";
            this.SPListsBox.Size = new System.Drawing.Size(146, 244);
            this.SPListsBox.TabIndex = 3;
            this.SPListsBox.SelectedValueChanged += new System.EventHandler(this.SPListsBox_SelectedValueChanged);
            // 
            // dtGridListItems
            // 
            this.dtGridListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridListItems.Location = new System.Drawing.Point(43, 339);
            this.dtGridListItems.Name = "dtGridListItems";
            this.dtGridListItems.RowTemplate.Height = 24;
            this.dtGridListItems.Size = new System.Drawing.Size(1000, 227);
            this.dtGridListItems.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "buttongrid ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnTitleSave_Click);
            // 
            // CsomPrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtGridListItems);
            this.Controls.Add(this.SPListsBox);
            this.Controls.Add(this.lblSiteTitle);
            this.Controls.Add(this.btnTitleSave);
            this.Controls.Add(this.txtSiteTitleChange);
            this.Name = "CsomPrac";
            this.Text = "Csom Practice Form";
            this.Load += new System.EventHandler(this.CsomPrac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridListItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSiteTitle;
        private System.Windows.Forms.TextBox txtSiteTitleChange;
        private System.Windows.Forms.Button btnTitleSave;
        private System.Windows.Forms.ListBox SPListsBox;
        private System.Windows.Forms.DataGridView dtGridListItems;
        private System.Windows.Forms.Button button1;
    }
}

