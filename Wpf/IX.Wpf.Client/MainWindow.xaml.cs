using System;
using System.Windows;

namespace IX.Wpf.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        protected Pusher.Client Client;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Client = new Pusher.Client();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic cmd = new { Name = "Carsten Jonstrup", Demo = "Niels" };
                Client.Push("commands", "action", cmd);
            }
            catch (Exception ex)
            {
                var i = ex;
            }
            
        }
    }
}
