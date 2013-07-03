using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarMatrixDataReader
{
    public class LbsOperator
    {
        public static async void CreateDatabox(string boxName)
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

        public static async void CreatePoin()
        {
            string url = "http://api.map.baidu.com/geodata/poi?method=create";
            var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new Dictionary<string, string>() { 
                {"databox_id","15263"},
                {"name","name3"},
                {"address","address3"},
                {"original_lat","31.218007745516"},
                {"original_lon","121.4870985565"},
                {"original_coord_type","3"},
                {"ak","6c72e0845dfce8ec0a3d432c33b2f778"}
            });
            var response = await httpClient.PostAsync(url, content);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
