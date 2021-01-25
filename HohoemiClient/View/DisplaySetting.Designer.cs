
namespace Hohoemi.View
{
    partial class DisplaySetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplaySetting));
            this._okButon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._displayDescription = new System.Windows.Forms.TextBox();
            this.screenViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._displayNames = new System.Windows.Forms.ComboBox();
            this.displayNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.screenViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayNamesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButon
            // 
            this._okButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButon.Location = new System.Drawing.Point(273, 97);
            this._okButon.Name = "_okButon";
            this._okButon.Size = new System.Drawing.Size(60, 23);
            this._okButon.TabIndex = 0;
            this._okButon.Text = "OK";
            this._okButon.UseVisualStyleBackColor = true;
            this._okButon.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "選択中のディスプレイ";
            // 
            // _displayDescription
            // 
            this._displayDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._displayDescription.Location = new System.Drawing.Point(15, 29);
            this._displayDescription.Multiline = true;
            this._displayDescription.Name = "_displayDescription";
            this._displayDescription.ReadOnly = true;
            this._displayDescription.Size = new System.Drawing.Size(316, 62);
            this._displayDescription.TabIndex = 3;
            // 
            // screenViewModelBindingSource
            // 
            this.screenViewModelBindingSource.DataSource = typeof(Hohoemi.ViewModel.ScreenViewModel);
            // 
            // _displayNames
            // 
            this._displayNames.FormattingEnabled = true;
            this._displayNames.Location = new System.Drawing.Point(123, 5);
            this._displayNames.Name = "_displayNames";
            this._displayNames.Size = new System.Drawing.Size(208, 20);
            this._displayNames.TabIndex = 6;
            // 
            // displayNamesBindingSource
            // 
            this.displayNamesBindingSource.DataMember = "DisplayNames";
            this.displayNamesBindingSource.DataSource = this.screenViewModelBindingSource;
            // 
            // DisplaySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 132);
            this.Controls.Add(this._displayNames);
            this.Controls.Add(this._displayDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._okButon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplaySetting";
            this.ShowInTaskbar = false;
            this.Text = "ディスプレイ設定";
            ((System.ComponentModel.ISupportInitialize)(this.screenViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayNamesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _displayDescription;
        private System.Windows.Forms.ComboBox _displayNames;
        private System.Windows.Forms.BindingSource screenViewModelBindingSource;
        private System.Windows.Forms.BindingSource displayNamesBindingSource;
    }
}