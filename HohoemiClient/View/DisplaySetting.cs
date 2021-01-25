using Hohoemi.ViewModel;
using System;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public partial class DisplaySetting : Form
    {
        private readonly ScreenViewModel _scrnVm = new ScreenViewModel();

        public DisplaySetting()
        {
            InitializeComponent();

            _displayDescription.DataBindings.Add("Text", _scrnVm, "ScreenDescription", false, DataSourceUpdateMode.OnPropertyChanged);
            _displayNames.DataSource = _scrnVm.DisplayNames;
            _displayNames.DataBindings.Add("SelectedIndex", _scrnVm, "SelectedIndex", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            _scrnVm.Update(_displayNames.SelectedIndex);
            Close();
        }
    }
}
