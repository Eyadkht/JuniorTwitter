using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Shared;
using System.Diagnostics;
using System.Threading;

namespace Server2Performance
{
   

   

    class S2
    {
        public class RemotingClient
        {
            public IManger Manger { get; private set; }

            public string remotingUrl = "http://localhost:1234/";

            public RemotingClient()
            {
                HttpChannel chnl = new HttpChannel();
                ChannelServices.RegisterChannel(chnl, false);

                Manger = (IManger)Activator.GetObject(typeof(IManger), remotingUrl + "ServerManger.soap");
            }
        }

        static PerformanceCounter theCPUCounter;
        static PerformanceCounter theMemCounter;
        static ServerInformation s;
        static float perfCounterValue;
        static RemotingClient _RemotingClient;

        static void Main(string[] args)
        {
            _RemotingClient = new RemotingClient();

            s = new ServerInformation();

            s.serverName = "S2";

            theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            theMemCounter = new PerformanceCounter("Memory", "Available MBytes");

            Thread thread1 = new Thread(new ThreadStart(SendServerPerformance));
            thread1.Start();

            Console.ReadLine();
        }
        static void SendServerPerformance()
        {

            while (true)
            {
                perfCounterValue = theCPUCounter.NextValue();

                System.Threading.Thread.Sleep(1000);
                perfCounterValue = theCPUCounter.NextValue();

                s.CpuUsage = perfCounterValue;
                //Thread has to sleep for at least 1 sec for accurate value.

                s.AvailableRam = theMemCounter.NextValue();

                Console.WriteLine("Memory={0}, CPU={1}", s.AvailableRam, s.CpuUsage);
                _RemotingClient.Manger.SendServerCost(s);
            }


        }
    }
}
