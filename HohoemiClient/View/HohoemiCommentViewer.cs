using Hohoemi.ViewModel;
using System;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class HohoemiCommentViewer : Form
    {
        private readonly HohoemiClientViewModel _clntVm = new HohoemiClientViewModel();

        public HohoemiCommentViewer()
        {
            InitializeComponent();

            _clntVm.OnMessageArrived += OnMessageArrived;

            _commentList.Columns.Add(new ColumnHeader()
            {
                Text = "ユーザ名",
                Width = (int)(_commentList.Width * 0.2)
            });

            _commentList.Columns.Add(new ColumnHeader()
            {
                Text = "コメント",
                Width = (int)(_commentList.Width * 0.8)
            });
        }

        private void OnMessageArrived(string user, string comment)
        {
            // 画面が表示されてない間は死ぬからバッファリングだけ
            if (Visible)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        var item = new ListViewItem(new string[] { user, comment });
                        _commentList.Items.Add(item);
                        _commentList.EnsureVisible(_commentList.Items.Count - 1);
                    }));
                }
                catch
                {
                    // GUIスレッドだしないと信じてるけど、FormClosing中にこっちの処理が刺さると死ぬ気がしたので念のため
                    // 何もしない。
                }
            }
        }

        private void CommentViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ×ボタン押されたときはキャンセル
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                // フォームは閉じない
                e.Cancel = true;

                // その代わり隠れる
                Hide();
            }
        }
    }
}
