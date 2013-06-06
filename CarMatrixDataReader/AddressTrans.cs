using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarMatrixDataReader
{
    public class AddressTrans
    {
        private HttpWebRequest request;
        private static readonly string UserAgent = "Mozilla/4.5";

        public void TransAddress()
        {

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
            catch
            {

            }
            return content;
        }
    }
}
