using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace SRTest.SignalR.Hubs
{ 
    [HubName("messagesHub")] //- found that case "M" effected whether this worked [I assume it has to be the same as JS].
    public class MessagesHub : Hub {
        private static IConnectionManager _connectionManager;

        public MessagesHub(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        [HubMethodName("SendMessages")] //changed casing ("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = _connectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();

            //Old code: Does not work, you have to inject IConnectionManager
            //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            //context.Clients.All.updateMessages();
        }
    }
}