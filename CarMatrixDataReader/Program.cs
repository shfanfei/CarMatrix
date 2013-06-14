using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarMatrixData;
using CarMatrixData.Models;

namespace CarMatrixDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = Enumerable.Range(0, 100).ToArray();
            //int len = nums.Count();
            //Parallel.For(0, len, i =>
            //{
            //    Console.WriteLine(i);
            //});
            string path = @"D:\temp.xlsx";
            FileOperator fo = new FileOperator(path);
            fo.LoadExcelData();

            //GetHttpContent();
            Console.WriteLine("{0}", "end");
            Console.ReadKey();
        }

        static void ReadExcelData()
        {
            string path = @"D:\temp.xlsx";
            FileOperator op = new FileOperator(path);
            DataSet ds = op.LoadDataFromExcel();
            if (ds != null && ds.Tables != null)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (!dt.TableName.Equals("_xlnm#_FilterDatabase"))
                    {
                        int count = dt.Columns.Count;
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                object obj = row[i];
                                Console.WriteLine("Column index is {0}. Object is {1}", i, obj.ToString());
                            }
                        }
                    }
                }
            }
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
