using Engine;
using Microsoft.UI.Xaml;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MetaWin
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlPanel : Window
    {
        public string NumberOfRows = "Enter Number Of Rows To Generate";
        public EventHandler DataUpdated;

        public readonly DataService dataService = DataService.Instance;

        public ControlPanel()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataService.RefreshData(int.Parse(NumberOfRows));
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
