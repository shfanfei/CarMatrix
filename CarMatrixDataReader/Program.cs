using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData;
using CarMatrixData.Models;

namespace CarMatrixDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var container = new ModelsContainer())
            //{
            //    Person p = new Person();
            //    p.Name = "jack";

            //    container.Set<Person>().Add(p);
            //    container.SaveChanges();
            //}

            string mapKey = ConfigurationManager.AppSettings["map_key"];
            string url = "http://api.map.baidu.com/geocoder/v2/" + "?address=百度大厦&output=xml&ak=" + mapKey;

            AddressTrans at = new AddressTrans();
            string content = at.HttpRequest(url);
            Console.WriteLine("{0}", content);
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
