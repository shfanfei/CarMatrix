using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixCore.Caching;
using CarMatrixData.Models;
using CarMatrixCore.Extensions;
using System.Collections.Concurrent;
using System.Threading;

namespace CarMatrixDataReader
{
    public class DbOperator
    {
        public static void InsertData(DataSet dataSet)
        {
            if (dataSet == null)
                throw new ArgumentNullException("DataSet param is null");

            try
            {
                //ConcurrentDictionary<string, object> cache = new ConcurrentDictionary<string, object>();
                ICacheManager cache = new MemoryCacheManager();

                var exceptions = new ConcurrentQueue<Exception>();
                List<Task> tasks = new List<Task>();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var container = new ModelsContainer())
                {
                    foreach (DataTable dt in dataSet.Tables)
                    {
                        //Task task = Task.Factory.StartNew(() =>
                        //{
                        try
                        {
                            Console.WriteLine("----------Table name is : {0}---------", dt.TableName);
                            int cursor = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                Record record = new Record();

                                string brandsName = dr[0].ToString();
                                var brands = cache.Get<Brands>(brandsName, () =>
                                {
                                    return new Brands() { Name = brandsName };
                                });
                                record.Brands = brands;

                                string modelsName = dr[1].ToString();
                                var models = cache.Get<Models>(modelsName, () =>
                                {
                                    return new Models() { Name = modelsName };
                                });
                                record.Models = models;

                                record.City = dr[2].ToString();
                                string dv = dr[3].ToString().Replace(".", "");
                                string d = string.Format("{0}-{1}-01", dv.Substring(0, 4), dv.Substring(4, 2)).Trim();
                                var buyYear = cache.Get<BuyYear>(d, () =>
                                {
                                    return new BuyYear() { Time = Convert.ToDateTime(d) };
                                });
                                record.BuyYear = buyYear;

                                d = string.Format("{0}-01-01", dr[4].ToString());
                                record.Both = DateTime.Parse(d);
                                bool g = dr[5].ToString().Equals("男") ? true : false;
                                record.Gender = Convert.ToBoolean(g);
                                record.Address = dr[6].ToString();
                                record.Zip = dr[7].ToString();

                                container.Set<Record>().Add(record);
                                Console.WriteLine("address {0}, cursor = {1}, threadId = {2}", record.Address, cursor, Thread.CurrentThread.ManagedThreadId);
                                cursor++;
                                if (cursor == 100)
                                {
                                    cursor = 0;
                                    container.SaveChanges();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            exceptions.Enqueue(ex);
                        }
                        //});
                        //tasks.Add(task);
                        container.SaveChanges();
                    }
                }

                //Task.WaitAll(tasks.ToArray());

                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
                if (exceptions.Any())
                {
                    Console.WriteLine("Parallel have exceptions, count = {0}", exceptions.Count());
                }
            }
            catch (Exception ex)
            {
                string msg = ex.OutputMessage();
                Console.WriteLine("{0}", msg);
            }
        }
    }
}
