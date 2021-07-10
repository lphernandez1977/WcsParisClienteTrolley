using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace WcsParis
{
    public class cPing
    {
        public Boolean PingServidores(string _ipServer) 
        {
            Ping ping = new Ping();
            int tiempo = 1;

            if (ping.Send(_ipServer, tiempo).Status == IPStatus.Success)
            {
                return true;
            }
            else 
            { 
                return false; 
            }       
        
        }
    }
}
