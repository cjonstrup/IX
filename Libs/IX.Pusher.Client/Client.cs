using System;

namespace IX.Pusher
{
    
    public class Client
    {
        private readonly PusherServer.Pusher _pusher;

        public Client()
        {
            _pusher = new PusherServer.Pusher("177397", "7b4abaf489e799ceeceb", "4505221232e1e8341ec9");
        }

        public void Push(string channel, string eventname, dynamic alarm)
        {
            try
            {
                _pusher.Trigger(channel, eventname, alarm);
            }
            catch (Exception ex)
            {
                var e = ex;
            }           
        }
    }
}
