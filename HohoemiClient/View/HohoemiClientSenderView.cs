using Hohoemi.ViewModel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HohoemiClientViewer.Properties;

namespace Hohoemi.View
{
    public partial class HohoemiClientSenderView : Form
    {
        private readonly int DefaultHeight;

        private readonly HohoemClientView _clntView = new HohoemClientView();

        private readonly HohoemiCommentViewer _cmntView = new HohoemiCommentViewer();

        private readonly HohoemiClientSenderViewModel _sndVm = new HohoemiClientSenderViewModel();

        private Color _commentColor = Color.Black;

        private bool _isCommentVisible = true;

        public HohoemiClientSenderView()
        {
            InitializeComponent();

            AcceptButton = _sendButton;
            DefaultHeight = Size.Height;

            _clntView.Show();
            _cmntView.Hide();

            UpdateCommentVisibleButton(_isCommentVisible);
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            // GUIで排他
            _sendButton.Enabled = false;
            _commentText.Enabled = false;

            // 今のところ、ユーザ名はPCユーザ名を使う
            string user = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            if (_sndVm.Send(user, _commentText.Text))
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

                _clntView.ChangeCommentColor(_commentColor);
            }
        }

        private void HohoemiClientSenderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _clntView.Close();

            _cmntView.Close();
        }

        private void DisplaySelectButton_Click(object sender, EventArgs e)
        {
            new DisplaySetting().ShowDialog();
        }

        private void CommentViewerButton_Click(object sender, EventArgs e)
        {
            if (!_cmntView.Visible)
            {
                _cmntView.Show();
            }
            else
            {
                _cmntView.Hide();
            }
        }

        private void UpdateCommentVisibleButton(bool visible)
        {
            if (visible)
            {
                _commentVisbleButton.Image = Resources.commentOn;
            }
            else
            {
                _commentVisbleButton.Image = Resources.commentOff;
            }
        }

        private void CommentVisibleButton_Click(object sender, EventArgs e)
        {
            _isCommentVisible = !_isCommentVisible;

            UpdateCommentVisibleButton(_isCommentVisible);

            _clntView.ChangeCommentVisibility(_isCommentVisible);
        }
    }
}
