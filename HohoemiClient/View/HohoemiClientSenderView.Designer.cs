namespace Hohoemi.View
{
    partial class HohoemiClientSenderView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HohoemiClientSenderView));
            this._commentText = new System.Windows.Forms.TextBox();
            this._sendButton = new System.Windows.Forms.Button();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._displaySelectButton = new System.Windows.Forms.ToolStripButton();
            this._colorckerButton = new System.Windows.Forms.ToolStripButton();
            this._commentViewerButton = new System.Windows.Forms.ToolStripButton();
            this._commentVisbleButton = new System.Windows.Forms.ToolStripButton();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _commentText
            // 
            this._commentText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._commentText.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._commentText.Location = new System.Drawing.Point(12, 28);
            this._commentText.Name = "_commentText";
            this._commentText.Size = new System.Drawing.Size(449, 22);
            this._commentText.TabIndex = 0;
            // 
            // _sendButton
            // 
            this._sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._sendButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._sendButton.Location = new System.Drawing.Point(467, 28);
            this._sendButton.Name = "_sendButton";
            this._sendButton.Size = new System.Drawing.Size(75, 23);
            this._sendButton.TabIndex = 1;
            this._sendButton.Text = "送信";
            this._sendButton.UseVisualStyleBackColor = true;
            this._sendButton.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(23, 23);
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._displaySelectButton,
            this._colorckerButton,
            this._commentViewerButton,
            this._commentVisbleButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(554, 25);
            this._toolStrip.TabIndex = 2;
            // 
            // _displaySelectButton
            // 
            this._displaySelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._displaySelectButton.Image = ((System.Drawing.Image)(resources.GetObject("_displaySelectButton.Image")));
            this._displaySelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._displaySelectButton.Name = "_displaySelectButton";
            this._displaySelectButton.Size = new System.Drawing.Size(23, 22);
            this._displaySelectButton.Text = "ディスプレイ選択";
            this._displaySelectButton.Click += new System.EventHandler(this.DisplaySelectButton_Click);
            // 
            // _colorckerButton
            // 
            this._colorckerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._colorckerButton.Image = ((System.Drawing.Image)(resources.GetObject("_colorckerButton.Image")));
            this._colorckerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._colorckerButton.Name = "_colorckerButton";
            this._colorckerButton.Size = new System.Drawing.Size(23, 22);
            this._colorckerButton.Text = "コメント色変更";
            this._colorckerButton.Click += new System.EventHandler(this.ColorckerButton_Click);
            // 
            // _commentViewerButton
            // 
            this._commentViewerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._commentViewerButton.Image = ((System.Drawing.Image)(resources.GetObject("_commentViewerButton.Image")));
            this._commentViewerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._commentViewerButton.Name = "_commentViewerButton";
            this._commentViewerButton.Size = new System.Drawing.Size(23, 22);
            this._commentViewerButton.Text = "コメントビューア表示";
            this._commentViewerButton.Click += new System.EventHandler(this.CommentViewerButton_Click);
            // 
            // _commentVisbleButton
            // 
            this._commentVisbleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._commentVisbleButton.Image = ((System.Drawing.Image)(resources.GetObject("_commentVisbleButton.Image")));
            this._commentVisbleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._commentVisbleButton.Name = "_commentVisbleButton";
            this._commentVisbleButton.Size = new System.Drawing.Size(23, 22);
            this._commentVisbleButton.Text = "コメント表示切替";
            this._commentVisbleButton.Click += new System.EventHandler(this.CommentVisibleButton_Click);
            // 
            // HohoemiClientSenderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 63);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._sendButton);
            this.Controls.Add(this._commentText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HohoemiClientSenderView";
            this.Text = "HohoemiClientSender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HohoemiClientSenderView_FormClosing);
            this.Resize += new System.EventHandler(this.HohoemiClientSenderView_Resize);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _commentText;
        private System.Windows.Forms.Button _sendButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _displaySelectButton;
        private System.Windows.Forms.ToolStripButton _colorckerButton;
        private System.Windows.Forms.ToolStripButton _commentViewerButton;
        private System.Windows.Forms.ToolStripButton _commentVisbleButton;
    }
}

