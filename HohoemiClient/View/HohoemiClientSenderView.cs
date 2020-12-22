using Hohoemi.ViewModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class HohoemiClientSenderView : Form
    {
        private readonly int DefaultHeight;

        private readonly HohoemClientView _view = new HohoemClientView();

        private Color _commentColor = Color.Black;

        public HohoemiClientSenderView()
        {
            InitializeComponent();

            AcceptButton = _sendButton;
            DefaultHeight = Size.Height;

            _view.Show();

            try
            {
                HohoemiClientViewModel.Init();
                HohoemiClientViewModel.OnMessageArrived += AppendMessage;
            }
            catch
            {
                MessageBox.Show("初期化に失敗しました。" + Environment.NewLine + Environment.CurrentDirectory + "\\hohoemi.configを確認してください。");
                Application.Exit();
            }
        }

        private void AppendMessage(object sendr, string message)
        {
            _view.AppendMessage(message, _commentColor);
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            // GUIで排他
            _sendButton.Enabled = false;
            _commentText.Enabled = false;

            if (HohoemiClientViewModel.Send(string.Empty, _commentText.Text))
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

        private void ColorckerButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _commentColor = colorDialog.Color;

                _view.ChangeCommentColor(_commentColor);
            }
        }

        private void HohoemiClientSenderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            HohoemiClientViewModel.Disconnect();

            _view.Close();
        }

        private void DisplaySelectButton_Click(object sender, EventArgs e)
        {
            new DisplaySetting().ShowDialog();
        }
    }
}
