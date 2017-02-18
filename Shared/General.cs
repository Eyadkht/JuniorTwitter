using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared
{
    public interface IManger
    {    
         
         int BestPerformance();
         void SendServerCost(ServerInformation s);  
            
         String SelectBestServer();

         int [] getServerCostById(int id);
         int[] CpuServersCost();

         int[] availableRamCost();
    }


    [Serializable]
    public class ServerInformation
    {
       public string serverName;
       public double CpuUsage;
       public double AvailableRam;                
    }

    
}
