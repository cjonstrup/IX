using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IX.Wpf.Gateway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IDisposable
    {
        private GatewayViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        public void Dispose()
        {
            try
            {
                _viewModel.Dispose();
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = _viewModel = new GatewayViewModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
    }
}
