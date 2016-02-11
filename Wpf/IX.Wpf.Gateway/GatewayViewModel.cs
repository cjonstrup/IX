using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace IX.Wpf.Gateway
{
    public class GatewayViewModel : DependencyObject, IDisposable
    {
        private Pusher.Gateway gateway;

        public GatewayViewModel()
        {
            try
            {
                gateway = new Pusher.Gateway();
                gateway.Commands += Gateway_Commands;

                Commands = new ObservableCollection<Cmd>();
            }
            catch (Exception ex)
            {

            }
        }

        private void Gateway_Commands(dynamic cmd)
        {
            try
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    Commands.Add(new Cmd() { Name = cmd.Name });
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static readonly DependencyProperty CommandsProperty = DependencyProperty.Register(
            "Commands", typeof(ObservableCollection<Cmd>), typeof(GatewayViewModel), new PropertyMetadata(default(ObservableCollection<Cmd>)));

        public ObservableCollection<Cmd> Commands
        {
            get { return (ObservableCollection<Cmd>)GetValue(CommandsProperty); }
            set { SetValue(CommandsProperty, value); }
        }

        public void Dispose()
        {
            gateway = null;
        }
    }

    public class Cmd
    {
        public string Name { get; set; }
    }
}
