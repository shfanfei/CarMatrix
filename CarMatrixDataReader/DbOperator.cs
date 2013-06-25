using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixDataReader
{
    public class DbOperator
    {
        public static void InsertData(DataSet dataSet)
        {
            if (dataSet == null)
                throw new ArgumentNullException("DataSet param is null");

            using (var container = new ModelsContainer())
            {
                foreach (DataTable dt in dataSet.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //Record record = new Record();
                        //record.Brands = dr[0].ToString();
                        //record.Model = dr[1].ToString();
                        //record.City = dr[2].ToString();
                        //string dv = dr[3].ToString().Replace(".", "");
                        //string d = string.Format("{0}-{1}-01", dv.Substring(0, 4), dv.Substring(4, 2)).Trim();
                        //record.Time = Convert.ToDateTime(d);
                        //d = string.Format("{0}-01-01", dr[4].ToString());
                        //record.Both = DateTime.Parse(d);
                        //bool g = dr[5].ToString().Equals("男") ? true : false;
                        //record.Gender = Convert.ToBoolean(g);
                        //record.Address = dr[6].ToString();
                        //record.Zip = dr[7].ToString();
                        //container.RecordSet.Add(record);
                    }
                    container.SaveChanges();
                }
            }
        }
    }
}
