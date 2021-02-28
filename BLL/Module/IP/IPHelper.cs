using NewronTestOWM.BLL.Interface;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Module
{
    internal class IPHelper : IIPHelper
    {
        public async Task<IPAddress> GetMyPublicIPAsync()
        {
            IPAddress ip = new IPAddress(0);
            IPAddress.TryParse(await GetMyPublicIPStringAsync(), out ip);
            return ip;
        }

        public async Task<string> GetMyPublicIPStringAsync()
        {
            using (WebClient client = new WebClient())
            {
                List<Uri> hosts = new List<Uri>();
                hosts.Add(new Uri("https://icanhazip.com"));
                hosts.Add(new Uri("https://api.ipify.org"));
                hosts.Add(new Uri("https://ipinfo.io/ip"));
                hosts.Add(new Uri("https://wtfismyip.com/text"));
                hosts.Add(new Uri("https://checkip.amazonaws.com/"));
                hosts.Add(new Uri("https://bot.whatismyipaddress.com/"));
                hosts.Add(new Uri("https://ipecho.net/plain"));
                foreach (Uri host in hosts)
                {
                    try
                    {
                        string ipAdressString = await client.DownloadStringTaskAsync(host);
                        ipAdressString = ipAdressString.Replace("\n", "");
                        if (!String.IsNullOrEmpty(ipAdressString))
                            return ipAdressString;
                    }
                    catch(WebException ex)
                    {
                        Logger log = LogManager.GetCurrentClassLogger();
                        log.Info("Error get ip from "+ host + " : " + ex);
                    }
                }
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error("Error get ip");
                return string.Empty;
            }
        }
    }
}
