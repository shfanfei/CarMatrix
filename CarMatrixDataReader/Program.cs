using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

            //string path = @"D:\temp.xlsx";
            //FileOperator op = new FileOperator(path);
            //DataSet ds = op.LoadDataFromExcel();
            //if (ds != null && ds.Tables != null)
            //{
            //    foreach (DataTable dt in ds.Tables)
            //    {
            //        if (!dt.TableName.Equals("_xlnm#_FilterDatabase"))
            //        {
            //            int count = dt.Columns.Count;                         

            //            foreach (DataRow row in dt.Rows)
            //            {
            //                for (int i = 0; i < count; i++)
            //                {
            //                    object obj = row[i];
            //                    Console.WriteLine("Column index is {0}.object is {1}", i, obj.ToString());
            //                }
            //            }
            //        }
            //    }
            //}


            GetHttpContent();
            Console.WriteLine("{0}", "end");
            Console.ReadKey();
        }

        static async void GetHttpContent()
        {
            AddressTrans at = new AddressTrans();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person p = new Person();
                p.Name = "name" + i.ToString();
                p.Address = "百度大厦";
                persons.Add(p);
            }

            foreach (var person in persons)
            {
                string url = at.BuildeUrl(person.Address.Trim());
                string content = await Task.Run(() =>
                {
                    Task.Delay(1000).Wait();
                    return at.Taskmethod(url);
                });
                at.ResolvePersonLocation(content, person);
                Console.WriteLine("person name is {0},lat is {1},lnt is {2}", person.Name, person.Lat, person.Lnt);
            }
        }
    }
}
