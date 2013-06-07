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

            //string mapKey = ConfigurationManager.AppSettings["map_key"];
            //string url = "http://api.map.baidu.com/geocoder/v2/" + "?address=百度大厦&output=xml&ak=" + mapKey;

            //AddressTrans at = new AddressTrans();
            //string content = at.HttpRequest(url);
            //Console.WriteLine("{0}", content);


            string path = @"D:\temp.xlsx";
            FileOperator op = new FileOperator(path);
            DataSet ds = op.LoadDataFromExcel();
            if (ds != null && ds.Tables != null)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (!dt.TableName.Equals("_xlnm#_FilterDatabase"))
                    {
                        //List<string> collectionName = new List<string>();
                        int count = dt.Columns.Count;
                        //foreach (DataColumnCollection dcc in dt.Columns)
                        //{
                        //    int count = dcc.Count;
                        //    for (int i = 0; i < count; i++)
                        //    {
                        //        DataColumn dc = dcc[i];
                        //        collectionName.Add(dc.ColumnName);
                        //    }
                        //}
                         

                        foreach (DataRow row in dt.Rows)
                        {
                            //foreach (string name in collectionName)
                            //{
                            for (int i = 0; i < count; i++)
                            {
                                object obj = row[i];
                                Console.WriteLine("Column index is {0}.object is {1}", i, obj.ToString());
                            }
                            //}
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
