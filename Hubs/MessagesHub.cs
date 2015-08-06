using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Orchard;

namespace SRTest.SignalR.Hubs
{
    [HubName("messagesHub")] //- found that case "M" effected whether this worked [I assume it has to be the same as JS].
    public class MessagesHub : Hub {

        //private readonly IOrchardServices services;

        //public MessagesHub(IOrchardServices services)
        //{
        //    this.services = services;
        //}

        [HubMethodName("SendMessages")] //changed casing ("sendMessages")]
        public static void SendMessages() //static
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();
            //Clients.All.updateMessages();
        }
    }
}