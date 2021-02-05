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

        private readonly ScreenViewModel _scrnVM = new ScreenViewModel();

        private Screen _targetScreen;

        private Color _commentColor = Color.Black;

        private HohoemiClientViewModel _clntVM = new HohoemiClientViewModel();
        public HohoemClientView()
        {
            InitializeComponent();

            _scrnVM.OnChangeCurrentScreen += OnScreenChanged;

            UpdateDrawnScreen(_scrnVM.CurrentScreen);

            _clntVM.OnMessageArrived += AppendMessage;
        }

        private void OnScreenChanged(Screen after)
        {
            Invoke(new Action(() =>
            {
                UpdateDrawnScreen(after);
            }));
        }

        private void UpdateDrawnScreen(Screen screen)
        {
            _targetScreen = screen;

            Location = new Point(_targetScreen.Bounds.X, _targetScreen.Bounds.Y);
            Width = _targetScreen.Bounds.Width;
            Height = _targetScreen.Bounds.Height;
        }

        private void HohoemClientView_Load(object sender, EventArgs e)
        {
            _cyclicTimer.Start();
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

        public void AppendMessage(string user, string message)
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
            int y = 0;

            // コメントがあった
            if (lastCmnt != null)
            {
                y = (lastCmnt.Location.Y + lastCmnt.Height);

                // 今の表示座標にコメントの高さを加算して文字切れしないか確認
                if ((y + commentSize.Height) > _targetScreen.Bounds.Height)
                {
                    y = 0;
                }
            }

            return new Point(x, y);
        }
        private void HohoemClientView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cyclicTimer != null)
            {
                _cyclicTimer.Stop();
                _cyclicTimer.Dispose();
            }

            _scrnVM.OnChangeCurrentScreen -= OnScreenChanged;
            _clntVM.OnMessageArrived -= AppendMessage;
        }

        public void ChangeCommentColor(Color commentColor)
        {
            lock (this)
            {
                _commentColor = commentColor;

                foreach (Label l in from Control c in Controls where c is Label select c)
                {
                    l.ForeColor = _commentColor;
                }
            }
        }

        public void ChangeCommentVisibility(bool visible)
        {
            lock (this)
            {
                foreach (Label l in from Control c in Controls where c is Label select c)
                {
                    l.Visible = visible;
                }
            }
        }
    }
}
