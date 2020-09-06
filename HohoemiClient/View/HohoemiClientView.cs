using Hohoemi.ViewModel;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class HohoemClientView : Form
    {
        private const int COMMENT_FLOW_SPEED = 20; /* px/timer_tick*/

        private HohoemiClientSenderView _senderView;
        private Color _commentColor = Color.Black;

        public HohoemClientView()
        {
            InitializeComponent();
        }

        private void HohoemClientView_Load(object sender, EventArgs e)
        {
            _cyclicTimer.Start();
            try
            {
                HohoemiClientViewModel.Init();
                HohoemiClientViewModel.OnMessageArrived += AppendMessage;

                CreateSendView();
            }
            catch
            {
                MessageBox.Show("初期化に失敗しました。" + Environment.NewLine + Environment.CurrentDirectory + "\\hohoemi.configを確認してください。");
                Application.Exit();
            }
        }

        private void CyclicTimerTick(object sender, EventArgs e)
        {
            lock (this)
            {
                foreach (var comment in from Control c in Controls where c is Label select c)
                {
                    // 画面外に来たら消す
                    if (comment.Location.X > Width)
                    {
                        Controls.Remove(comment);
                    }
                    else
                    {
                        // そうじゃなかったら動かす
                        comment.Location = new Point(comment.Location.X + COMMENT_FLOW_SPEED, comment.Location.Y);
                    }
                }
            }
        }

        private void AppendMessage(object sendr, string message)
        {
            // デバッグ中にフォーム閉じるとここで例外飛ぶけど、無視してください(◞‸◟)
            Invoke(new Action(() =>
            {
                var comment = new Label()
                {
                    Text = message,
                    AutoSize = true,
                    Font = new Font("メイリオ", 20),
                    ForeColor = _commentColor
                };

                comment.Location = GetCommentInitialLocation(comment.Size);

                Controls.Add(comment);
            }));
        }

        private Point GetCommentInitialLocation(Size commentSize)
        {
            // コントロールで一番最後に追加したやつの下にコメント追加
            // 画面の高さ上限を超えた場合は、上から追加
            var lastCmnt = (from Control c in Controls where c is Label select c).LastOrDefault();

            // 初期ポジション
            int x = -commentSize.Width;
            int y = _toolStrip.Height;

            // コメントがあった
            if (lastCmnt != null)
            {
                y = (lastCmnt.Location.Y + lastCmnt.Height);

                // 今の表示座標にコメントの高さを加算して文字切れしないか確認
                if ((y + commentSize.Height) > Height)
                {
                    y = _toolStrip.Height;
                }
            }

            return new Point(x, y);
        }
       private void HohoemClientView_FormClosing(object sender, FormClosingEventArgs e)
        {
            HohoemiClientViewModel.Disconnect();

            if (_cyclicTimer != null)
            {
                _cyclicTimer.Stop();
                _cyclicTimer.Dispose();
            }
        }

        private void ShowSenderButton_Click(object sender, EventArgs e)
        {
            if (_senderView.IsDisposed)
            {
                // 作り直し
                CreateSendView();
            }
            else
            {
                _senderView.Activate();
            }
        }

        private void CreateSendView()
        {
            _senderView = new HohoemiClientSenderView()
            {
                Visible = false,
                Width = Width
            };

            // デフォルトの表示位置変えられられないので、非表示⇒移動⇒表示する
            _senderView.Show(this);
            _senderView.Location = new Point(Location.X, Location.Y + Height);
            _senderView.Visible = true;
        }

        private void ColorckerButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                _commentColor = colorDialog.Color;

                lock(this)
                {
                    foreach(Label l in from Control c in Controls where c is Label select c)
                    {
                        l.ForeColor = _commentColor;
                    }
                }
            }
        }
    }
}
