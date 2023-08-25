using Engine;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MetaWin
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // This should all be done with DI but this is jsut a test
        public readonly DataService dataService = DataService.Instance;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var controlPanel = new ControlPanel();
            controlPanel.DataUpdated += (sender, e) =>
            {
                // This is a bit of a hack to make it work with a data table for the demo.
                // A far far better approch would be to make your table an observable collection
                // or at least make use the PropertyChanged event
                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = dataService.Rows;
            };

            controlPanel.Activate();
        }
    }
}
