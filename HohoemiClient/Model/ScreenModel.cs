using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hohoemi.Model
{
    // ディスプレイ情報を管理するクラス。シングルトン
    public class ScreenModel
    {
        private ScreenModel()
        {
        }

        public static Screen Default
        {
            get
            {
                return Screen.PrimaryScreen;
            }
        }

        public static ScreenModel Object
        {
            get;

            private set;
        } = new ScreenModel();

        public event Action<Screen> OnScreenChanged = delegate { };

        private Screen _crrentScreen = Screen.PrimaryScreen;
        public Screen CurrentScreen
        {
            get
            {
                // 抜き差しとかされたたら存在していないディスプレイを返すため
                // ディスプレイ取得時に今選択しているディスプレイが存在しているか確認
                if (AllScreens.Contains(_crrentScreen))
                {
                    return _crrentScreen;
                }
                else
                {
                    // ここに来た場合は、抜き差しされてる
                    // getで副作用を起こすのはよくないのでnullを返しておく
                    return null;
                }
            }

            set
            {
                _crrentScreen = value;

                OnScreenChanged(_crrentScreen);
            }
        }

        public List<Screen> AllScreens
        {
            get
            {
                return Screen.AllScreens.ToList();
            }
        }
    }
}
