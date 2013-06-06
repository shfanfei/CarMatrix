using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

        public void GetPersonAddressLocation(IEnumerable<Person> persons)
        {
            if (persons != null)
            {
                foreach (Person person in persons)
                {
                    if (!string.IsNullOrEmpty(person.Address))
                    {
                        string url = BuildeUrl(person.Address);
                        string content = HttpRequest(url);
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

        public string HttpRequest(string url)
        {
            string content = "";
            try
            {
                this.request = HttpWebRequest.Create(url) as HttpWebRequest;
                this.request.Method = "GET";
                this.request.UserAgent = UserAgent;

                Stream stream = this.request.GetResponse().GetResponseStream();
                using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("get request has exception,{0}", ex);
            }
            return content;
        }

        public void ResolvePersonLocation(string content)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(content);

        }
    }
}
