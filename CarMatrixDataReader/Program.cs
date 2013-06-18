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
            string path = @"D:\temp.xlsx";
            FileOperator fo = new FileOperator(path);
            fo.LoadExcelData();
            DbOperator.InsertData(fo.DataSet);
            
            //GetHttpContent();

            Console.WriteLine("{0}", "End");
            Console.ReadKey();
        }

        static void GetHttpContent()
        {
            Task task = Task.Factory.StartNew(() =>
                {
                    AddressTrans at = new AddressTrans();
                    List<Record> records = new List<Record>();
                    for (int i = 0; i < 100; i++)
                    {
                        Record p = new Record();
                        p.Brands = i.ToString();
                        p.Address = "百度大厦";
                        records.Add(p);
                    }

                    foreach (var person in records)
                    {
                        Task.Delay(100).Wait();
                        Task t = Task.Factory.StartNew(async () =>
                            {
                                string url = at.BuildeUrl(person.Address.Trim());
                                await at.TransLocation(person, url);
                                Console.WriteLine("Name : {0}, Lat = {1}, Lnt = {2}, ThreadId = {3}",
                                    person.Brands, person.Lat, person.Lnt, Thread.CurrentThread.ManagedThreadId);

                            });
                    }
                });
        }
    }
}
