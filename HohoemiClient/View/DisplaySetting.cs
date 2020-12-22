using Hohoemi.ViewModel;
using System;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class DisplaySetting : Form
    {
        public Screen SelectedScreen
        {
            get { return ScreenViewModel.Selected; }
        }

        public DisplaySetting()
        {
            InitializeComponent();

            _screenNames.Items.AddRange(ScreenViewModel.DisplayNames);
            _screenNames.SelectedIndex = ScreenViewModel.SelectedIndex;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            ScreenViewModel.SelectedIndex = _screenNames.SelectedIndex;
            
            Close();
        }

        private void _screenNames_SelectedItemChanged(object sender, EventArgs e)
        {
            _displayDescription.Text = ScreenViewModel.ScreenDescription;
        }
    }
}
