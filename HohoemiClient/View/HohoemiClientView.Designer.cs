﻿namespace Hohoemi.View
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
            this._cyclicTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _cyclicTimer
            // 
            this._cyclicTimer.Tick += new System.EventHandler(this.CyclicTimerTick);
            // 
            // HohoemClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HohoemClientView";
            this.ShowIcon = false;
            this.Text = "HohoemiClientViewer";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ScrollBar;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HohoemClientView_FormClosing);
            this.Load += new System.EventHandler(this.HohoemClientView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer _cyclicTimer;
    }
}

