using Hohoemi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hohoemi.ViewModel
{
    public class ScreenViewModel
    {
        public Action<Screen> OnChangeCurrentScreen = delegate { };

        public ScreenViewModel()
        {
            ScreenModel.Object.OnScreenChanged += Notify;
        }

        private void Notify(Screen selected)
        {
            OnChangeCurrentScreen(selected);
        }

        public void Update(int index)
        {
            try
            {
                ScreenModel.Object.CurrentScreen = ScreenModel.Object.AllScreens[index];
            }
            catch
            {
                // 自分で選んでおいて、ディスプレイを抜くやつがいるらしい
                // 何もしない。
            }
        }

        // CurrentはModelにまで設定されているものを示す
        public Screen CurrentScreen
        {
            get
            {
                var screen = ScreenModel.Object.CurrentScreen;

                if (screen != null)
                {
                    return screen;
                }
                else
                {
                    // 画面にnullはきついのでDefaultを返しておく
                    return ScreenModel.Default;
                }
            }
        }


        // Selectedは今の画面で選択されているものを示す
        private Screen _selected = ScreenModel.Object.CurrentScreen;

        public int SelectedIndex
        {
            get
            {
                int index = SearchSelectedScreenIndex(_selected);


                if (index > 0)
                {
                    return index;
                }
                else
                {
                    // ここに来た場合、ディスプレイの取り外しとかで、記憶していたディスプレイがなくなっている
                    // デフォルトスクリーンのindexを返す(モデルの値は変えない)
                    return SearchSelectedScreenIndex(ScreenModel.Default);
                }
            }

            set
            {
                try
                {
                    _selected = ScreenModel.Object.AllScreens[value];
                }
                catch
                {
                    // ここに来た場合、ディスプレイの取り外しとかで、記憶していたディスプレイがなくなっている
                    // Defaultを選択状態にする
                    _selected = ScreenModel.Default;
                }
            }
        }

        private int SearchSelectedScreenIndex(Screen selected)
        {
            for (int i = 0; i < Screen.AllScreens.Length; ++i)
            {
                if (ScreenModel.Object.AllScreens[i].Equals(selected))
                {
                    return i;
                }
            }

            // ここに来たときは、引数が存在しないScreenオブジェクトだった場合
            return -1;
        }

        public IList<string> DisplayNames
        {
            get
            {
                return (from s in ScreenModel.Object.AllScreens select s.DeviceName).ToArray();
            }
        }

        public string ScreenDescription
        {
            get
            {
                // ディスプレイ抜き差しによってSelectedがnullになっている可能性があるのでチェック
                if (_selected != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Width  = {_selected.Bounds.Width}");
                    sb.AppendLine($"Height = {_selected.Bounds.Height}");
                    return sb.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
