namespace Hohoemi.View
{
    partial class HohoemClientView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HohoemClientView));
            this._cyclicTimer = new System.Windows.Forms.Timer(this.components);
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._showSenderButton = new System.Windows.Forms.ToolStripButton();
            this._colorckerButton = new System.Windows.Forms.ToolStripButton();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cyclicTimer
            // 
            this._cyclicTimer.Tick += new System.EventHandler(this.CyclicTimerTick);
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showSenderButton,
            this._colorckerButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(784, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _showSenderButton
            // 
            this._showSenderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._showSenderButton.Image = ((System.Drawing.Image)(resources.GetObject("_showSenderButton.Image")));
            this._showSenderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._showSenderButton.Name = "_showSenderButton";
            this._showSenderButton.Size = new System.Drawing.Size(23, 22);
            this._showSenderButton.Text = "コメントウィンドウを表示";
            this._showSenderButton.Click += new System.EventHandler(this.ShowSenderButton_Click);
            // 
            // _colorckerButton
            // 
            this._colorckerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._colorckerButton.Image = ((System.Drawing.Image)(resources.GetObject("_colorckerButton.Image")));
            this._colorckerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._colorckerButton.Name = "_colorckerButton";
            this._colorckerButton.Size = new System.Drawing.Size(23, 22);
            this._colorckerButton.Text = "文字色変更";
            this._colorckerButton.Click += new System.EventHandler(this.ColorckerButton_Click);
            // 
            // HohoemClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._toolStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "HohoemClientView";
            this.ShowIcon = false;
            this.Text = "HohoemiClientViewer";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ScrollBar;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HohoemClientView_FormClosing);
            this.Load += new System.EventHandler(this.HohoemClientView_Load);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer _cyclicTimer;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _showSenderButton;
        private System.Windows.Forms.ToolStripButton _colorckerButton;
    }
}

