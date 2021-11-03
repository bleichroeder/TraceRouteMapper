using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading;

namespace TraceRouteMapper.DataAccess
{
    public class LocationAccess
    {
        public GeoLocation ReturnGeoLocationFromIP(string ipAddress)
        {
            GeoLocation response = new GeoLocation();

            int attempts = 0;
            bool success = false;
            while(!success && attempts < 10)
            {
                try
                {
                    using (WebClient c = new WebClient())
                    {
                        response = JsonConvert.DeserializeObject<GeoLocation>(
                            c.DownloadString("http://api.ipstack.com/" + ipAddress + "?access_key=[ACCESSKEY]" + "&hostname=1")
                            );
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    attempts++;
                }
                Thread.Sleep(500);
            }
            
            return response;
        }
    }
}
