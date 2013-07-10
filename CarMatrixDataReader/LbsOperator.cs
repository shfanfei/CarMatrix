using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixDataReader
{
    public class LbsOperator
    {
        private HttpClient httpClient;

        public LbsOperator()
        {
            this.httpClient = new HttpClient();
        }

        public async void CreateDatabox(string boxName)
        {
            string url = "http://api.map.baidu.com/geodata/databox?method=create";
            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"name", boxName },
                {"ak","6c72e0845dfce8ec0a3d432c33b2f778"}
            });
            var response = await httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content);
        }

        public async void CreatePoin(Record record)
        {
            string url = "http://api.map.baidu.com/geodata/poi?method=create";
            var content = new FormUrlEncodedContent(new Dictionary<string, string>() { 
                {"databox_id",ApplicationData.DataboxId },
                {"name",record.Id.ToString()},
                {"address",record.Address},
                {"original_lat",record.Lat.ToString()},
                {"original_lon",record.Lnt.ToString()},
                {"original_coord_type","3"},
                {"ak",ApplicationData.MapKey}
            });
            var response = await httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
