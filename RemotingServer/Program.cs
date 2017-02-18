using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using Shared;

namespace RemotingServer
{
    class Program
    {

        public class ServerManger : MarshalByRefObject, IManger
        {           
            ServerInformation S1;
            ServerInformation S2;
            ServerInformation S3;


            public void SendServerCost(ServerInformation s)
            {

                if(s.serverName=="S1" )
                {                   
                    S1 = s;
                    Console.WriteLine("Server 1: Memory={0}, CPU={1}", S1.AvailableRam, S1.CpuUsage);
                }
                
                if (s.serverName == "S2")
                {
                    S2 = s;
                    Console.WriteLine("Server 2: Memory={0}, CPU={1}", S2.AvailableRam, S2.CpuUsage);
                }
                if(s.serverName == "S3")
                {
                    S3 = s;
                    Console.WriteLine("Server 3: Memory={0}, CPU={1}", S3.AvailableRam, S3.CpuUsage);
                }

                Console.WriteLine("*******");
            }

            public string SelectBestServer()
            {
                int x = BestPerformance() + 1;
                return "Server"+x ;
            }

            public int BestPerformance()
            {
                Double performance1 = S1.CpuUsage * S1.AvailableRam * 2;
                Double performance2 = S2.CpuUsage * S2.AvailableRam * 2;
                Double performance3 = S3.CpuUsage * S3.AvailableRam * 2;

                Double[] array = { performance1, performance2, performance3 };

                //System.Console.WriteLine("THis is {0},{1},{2}", array[0], array[1], array[2]);

                Double max = array.Max();
                Double min = array.Min();

                return Array.IndexOf(array, min);
            }

            public int[] getServerCostById(int id)
            {
               if (id == 1)
                {
                    return new int[] { (int) S1.CpuUsage, (int)S1.AvailableRam };
                }
               else if( id==2)
                {
                    return new int[] { (int)S2.CpuUsage, (int)S2.AvailableRam };
                }
               else if ( id==3)
                {
                    return new int[] { (int)S3.CpuUsage, (int)S3.AvailableRam };
                }

                return new int[] { -1, -1 };
            }

            
            public int[] CpuServersCost()
            {
                return new int[] { (int)S1.CpuUsage, (int)S2.CpuUsage, (int)S3.CpuUsage };
            }

            public int[] availableRamCost()
            {
                return new int[] { (int)S1.AvailableRam, (int)S2.AvailableRam, (int)S3.AvailableRam };
            }

        }

        static void Main(string[] args)
        {
            HttpChannel chnl = new HttpChannel(1234);
            ChannelServices.RegisterChannel(chnl, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerManger)
                , "ServerManger.soap"
                , WellKnownObjectMode.Singleton
                );

            System.Console.WriteLine("Remoting Server Started");
            Console.ReadKey();
        }
    }
}
