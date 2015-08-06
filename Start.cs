using System.Data.SqlClient;
using Autofac;

//Inspiration: http://sadomovalex.blogspot.com.au/2014/03/startup-code-in-orchard-module.html
//also see: \src\Orchard\Caching\CacheModule.cs

namespace SRTest.SignalR
{
    public class Start : Module {

        private bool isInitialized = false;

        protected override void Load(ContainerBuilder builder) {
            if (!isInitialized) {
                //Temp DB
                //string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlDependency.Start("Data Source = CNS; Initial Catalog = BlogDemos; Integrated Security = True;");
                isInitialized = true;
            }
        }
    }
}