using Hohoemi.ViewModel;
using System;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class HohoemiClientSenderView : Form
    {
        private readonly int DefaultHeight;

        public HohoemiClientSenderView()
        {
            InitializeComponent();

            AcceptButton = _sendButton;

            DefaultHeight = Height;
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            // GUIで排他
            _sendButton.Enabled = false;
            _commentText.Enabled = false;

            if(HohoemiClientViewModel.Send(string.Empty, _commentText.Text))
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
            _commentText.Focus();
        }

        private void HohoemiClientSenderView_Resize(object sender, EventArgs e)
        {
            Height = DefaultHeight;
        }
    }
}
