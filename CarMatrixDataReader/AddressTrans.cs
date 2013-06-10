using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using CarMatrixData.Models;

namespace CarMatrixDataReader
{
    public class AddressTrans
    {
        private string mapKey;

        public AddressTrans()
        {
            mapKey = ConfigurationManager.AppSettings["map_key"];
        }

        public string BuildeUrl(string address)
        {
            return string.Format("http://api.map.baidu.com/geocoder/v2/?address={0}&output=xml&ak={1}", address, mapKey); ;
        }

        public async Task<string> Taskmethod(string url)
        {
            var httpClient = new HttpClient();
            string content = (await httpClient.GetStringAsync(url));
            return content;
        }

        public void ResolvePersonLocation(string content, Person person)
        {
            XDocument xDoc = XDocument.Parse(content);
            var status = (from s in xDoc.Elements("GeocoderSearchResponse").Elements("status")
                          select s.Value).FirstOrDefault();

            if (!string.IsNullOrEmpty(status))
            {
                int statusInt = Convert.ToInt32(status);
                if (statusInt == 0)
                {
                    var lat = (from a in xDoc.Elements("GeocoderSearchResponse")
                                   .Elements("result")
                                   .Elements("location")
                                   .Elements("lat")
                               select a.Value).FirstOrDefault();
                    var lnt = (from a in xDoc.Elements("GeocoderSearchResponse")
                                   .Elements("result")
                                   .Elements("location")
                                   .Elements("lng")
                               select a.Value).FirstOrDefault();
                    person.Lat = Convert.ToDouble(lat);
                    person.Lnt = Convert.ToDouble(lnt);
                }
                else
                {
                    Console.WriteLine("Get xml status error,status is {0}", status);
                }
            }
            else
            {
                Console.WriteLine("Get xml status error,status is null");
            }
        }
    }
}
