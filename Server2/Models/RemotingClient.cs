using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using Shared;

namespace Server2.Models
{
    public class RemotingClient
    {    
        public IManger  Manger { get; private set; }

        public string remotingUrl = "http://localhost:1234/";

        public RemotingClient()
        {
            HttpChannel chnl = new HttpChannel();
            ChannelServices.RegisterChannel(chnl, false);         

            Manger = (IManger)Activator.GetObject(typeof(IManger), remotingUrl + "ServerManger.soap");
        }
    }
}