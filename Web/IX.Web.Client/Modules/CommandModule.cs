using System;
using Nancy;

namespace IX.Web.Client.Modules
{
    public class CommandModule : NancyModule
    {
        private IX.Pusher.Client Client;
        public CommandModule()
        {
            Client = new Pusher.Client();

            dynamic cmd = new { Name = "Carsten Jonstrup", Demo = "Niels" };

            Post["/alarm/ack"] = x =>
            {
                Client.Push("commands", "action", cmd);
                return "Ok";
            };
        }
    }
}