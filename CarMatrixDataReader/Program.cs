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
using CarMatrixCore.Extensions;


namespace CarMatrixDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(() =>
                {
                    string path = ConfigurationManager.AppSettings["file_path"];
                    FileOperator fo = new FileOperator(path);
                    fo.LoadExcelData();
                    DbOperator.InsertData(fo.DataSet);
                });
            task.Wait();
            Console.WriteLine("----Finish Read Excel Data----");
            GetHttpContent();
            Console.WriteLine("{0}", "----All Finish----");
            Console.ReadKey();
        }

        static async void GetHttpContent()
        {
            //Task task = Task.Factory.StartNew(() =>
            //    {
            try
            {
                AddressTrans at = new AddressTrans();
                using (var container = new ModelsContainer())
                {
                    var records = container.Set<Record>().ToList();
                    int cursor = 0;
                    foreach (var record in records)
                    {
                        if (record.Lat == null || record.Lnt == null)
                        {
                            Thread.Sleep(20);
                            if (!string.IsNullOrEmpty(record.Address))
                            {
                                try
                                {
                                    string url = at.BuildeUrl(record.Address.Trim().Replace(" ", ""));
                                    await at.TransLocation(record, url);
                                    Console.WriteLine("Lat = {0}, Lnt = {1}, cursor = {2}", record.Lat, record.Lnt, cursor);
                                }
                                catch (Exception ex)
                                {
                                    string msg = ex.OutputMessage();
                                    Console.WriteLine("trans address exception {0}", msg);
                                }
                                cursor++;
                                if (cursor == 100)
                                {
                                    cursor = 0;
                                    container.SaveChanges();
                                }
                            }
                        }
                    }
                    container.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.OutputMessage();
                Console.WriteLine("exception message:{0}", msg);
            }
            //});
            //task.Wait();
            Console.WriteLine("----Finish Trans Location----");
        }
    }
}
