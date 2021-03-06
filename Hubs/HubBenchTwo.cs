﻿//using JetBrains.Annotations;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Orchard.Environment.Extensions;

namespace SRTest.SignalR.Hubs
{
    //[OrchardFeature("Proligence.SignalR.Core.Samples")]//, UsedImplicitly]
    public class HubBenchTwo : Hub
    {
        public static int Connections;

        public void HitMe(long start, int clientCalls, string connectionId)
        {
            var tasks = new List<Task>();
            for (int i = 0; i < clientCalls; i++)
            {
                tasks.Add(Clients.Client(connectionId).stepOne());
            }

            Task.WaitAll(tasks.ToArray());

            Clients.Client(connectionId).doneOne(start, clientCalls).Wait();
        }

        public void HitUs(long start, int clientCalls)
        {
            for (int i = 0; i < clientCalls; i++)
            {
                Clients.All.stepAll().Wait();
            }

            Clients.All.doneAll(start, clientCalls, Connections, Context.ConnectionId).Wait();
        }

        public override Task OnConnected()
        {
            Interlocked.Increment(ref HubBenchTwo.Connections);
            return null;
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Interlocked.Decrement(ref HubBenchTwo.Connections);
            return null;
        }
    }
}