﻿
namespace Hohoemi.View
{
    partial class HohoemiCommentViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HohoemiCommentViewer));
            this._commentList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // _commentList
            // 
            this._commentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._commentList.HideSelection = false;
            this._commentList.Location = new System.Drawing.Point(13, 13);
            this._commentList.Name = "_commentList";
            this._commentList.Size = new System.Drawing.Size(775, 425);
            this._commentList.TabIndex = 0;
            this._commentList.UseCompatibleStateImageBehavior = false;
            this._commentList.View = System.Windows.Forms.View.Details;
            // 
            // HohoemiCommentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._commentList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HohoemiCommentViewer";
            this.Text = "HohoemiCommentViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommentViewer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _commentList;
    }
}