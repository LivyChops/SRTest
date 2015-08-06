using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Routes;

namespace SRTest.SignalR
{
    //[OrchardFeature("Proligence.SignalR.Core.Samples")]
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 12,
                    Route = new Route(
                        "Sig/{action}",
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"},
                            {"controller", "Sig"},
                            {"action", "Index"},
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Priority = 13,
                    Route = new Route(
                        "Sig/Test",
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"},
                            {"controller", "Sig"},
                            {"action", "Test"},
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Priority = 14,
                    Route = new Route(
                        "Sig/GetMessages",
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"},
                            {"controller", "Sig"},
                            {"action", "GetMessages"},
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Priority = 15,
                    Route = new Route(
                        "Sig/Benchmark",
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"},
                            {"controller", "Sig"},
                            {"action", "Benchmark"},
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "SRTest.SignalR"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}