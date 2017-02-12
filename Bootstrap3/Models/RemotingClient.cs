using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using Shared;

namespace Bootstrap3.Models
{
    public class RemotingClient
    {    
        public IManger  Manger { get; private set; }

        public string remotingUrl = "http://localhost:1234/";

        public RemotingClient()
        {

            HttpChannel channel = new HttpChannel();
            if (ChannelServices.RegisteredChannels.Any(e => e == channel))
            {
                ChannelServices.RegisterChannel(channel, false);
            }

            Manger = (IManger)Activator.GetObject(typeof(IManger), remotingUrl + "ServerManger.soap");
        }
    }
}