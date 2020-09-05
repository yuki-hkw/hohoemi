using Hohoemi.ViewModel;
using System;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class HohoemiClientSenderView : Form
    {
        private HohoemiClientSenderViewModel _vm;

        public HohoemiClientSenderView()
        {
            InitializeComponent();

            AcceptButton = _sendButton;
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            // GUIで排他
            _sendButton.Enabled = false;
            _commentText.Enabled = false;

            if(_vm.Send(string.Empty, _commentText.Text))
            {
                // 成功したらコメント空にする
                _commentText.Text = string.Empty;
            }

            _commentText.Enabled = true;
            _commentText.Focus();
            _sendButton.Enabled = true;
        }

        private void HohoemiClientSenderView_Load(object sender, EventArgs e)
        {
            try
            {
                _vm = new HohoemiClientSenderViewModel();

                _commentText.Focus();
            }
            catch
            {
                MessageBox.Show("初期化に失敗しました。" + Environment.NewLine + Environment.CurrentDirectory + "\\hohoemi.configを確認してください。");
                Application.Exit();
            }
        }

        private void HohoemiClientSenderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_vm != null)
            {
                _vm.Disconnect();
            }
        }
    }
}
