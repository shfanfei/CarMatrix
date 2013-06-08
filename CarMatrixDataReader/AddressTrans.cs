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
        private HttpWebRequest request;
        private string mapKey;
        private static readonly string UserAgent = "Mozilla/4.5";
        //private static readonly string server = "http://api.map.baidu.com/geocoder/v2/";

        public void TransAddress()
        {
            mapKey = ConfigurationManager.AppSettings["map_key"];
        }

        public async void GetPersonAddressLocation(IEnumerable<Person> persons)
        {
            if (persons != null)
            {
                foreach (Person person in persons)
                {
                    if (!string.IsNullOrEmpty(person.Address))
                    {
                        string url = BuildeUrl(person.Address);
                        string content = await Taskmethod(url);
                        if (!string.IsNullOrEmpty(content))
                        {
                            // TO DO 

                        }
                    }
                }
            }
            else
                Console.WriteLine("{0}", "person params is null");
        }

        public string BuildeUrl(string address)
        {
            return string.Format("http://api.map.baidu.com/geocoder/v2/?address={0}&output=xml&ak={1}", address, mapKey); ;
        }

        //public string HttpRequest(string url)
        //{
        //    string content = "";
        //    try
        //    {
        //        this.request = HttpWebRequest.Create(url) as HttpWebRequest;
        //        this.request.Method = "GET";
        //        this.request.UserAgent = UserAgent;

        //        Stream stream = this.request.GetResponse().GetResponseStream();
        //        using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
        //        {
        //            content = sr.ReadToEnd();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("get request has exception,{0}", ex);
        //    }
        //    return content;
        //}



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
