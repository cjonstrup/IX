using System;
using PusherClient;

namespace IX.Pusher
{
    public class Gateway
    {
        public event AcknowledEventHandler Acknowled;
        public delegate void AcknowledEventHandler(dynamic alarm);

        public event CommandEventHandler Commands;
        public delegate void CommandEventHandler(dynamic cmd);

        public Gateway()
        {
            PusherClient.Pusher pusher = new PusherClient.Pusher("7b4abaf489e799ceeceb");

            Channel alarmChannel = pusher.Subscribe("alarms");
            Channel cmdChannel = pusher.Subscribe("commands");

            alarmChannel.Bind("ack", (dynamic data) =>
            {
                try
                {
                    EventAcknowled(data);
                }
                catch (Exception ex)
                {
                    var e = ex;
                }

            });

            cmdChannel.Bind("action", (dynamic data) =>
            {
                try
                {
                    EventCommand(data);
                }
                catch (Exception ex)
                {
                    var e = ex;
                }

            });

            pusher.Connect();
        }

        protected virtual void EventCommand(dynamic cmd)
        {
            try
            {
                var commands = Commands;
                if (commands != null)
                {
                    commands.Invoke(cmd);
                }
            }
            catch (Exception ex)
            {
                var ex1 = ex;
            }
        }

        protected virtual void EventAcknowled(dynamic alarm)
        {
            try
            {
                var acknowled = Acknowled;
                if (acknowled != null)
                {
                    acknowled.Invoke(alarm);
                }
            }
            catch (Exception ex)
            {
                var ex1 = ex;
            }
        }
    }
}
