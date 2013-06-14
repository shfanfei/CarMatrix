using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarMatrixDataReader
{
    public class FileOperator
    {
        private string filePath;
        private string strConn;

        public FileOperator(string filePath)
        {
            this.filePath = filePath;
            this.strConn = DBConnectionStr();
        }

        public void LoadExcelData()
        {
            try
            {
                List<string> nameList = new List<string>();

                string strConn = DBConnectionStr();
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow dr in dt.Rows)
                {
                    if ((string)dr["TABLE_NAME"] != "_xlnm#_FilterDatabase")
                    {
                        nameList.Add((string)dr["TABLE_NAME"]);
                    }
                }
                

                DataSet OleDsExcle = new DataSet();
                //System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

                foreach (var name in nameList)
                {
                    string sql = string.Format("SELECT * FROM  [{0}]", name);
                    OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, conn);
                    OleDaExcel.Fill(OleDsExcle, name);
                }

                //stopWatch.Stop();
                conn.Close();


                //TimeSpan ts = stopWatch.Elapsed;
                //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                //    ts.Hours, ts.Minutes, ts.Seconds,
                //    ts.Milliseconds / 10);
                //Console.WriteLine("RunTime " + elapsedTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadDataFromExcel()
        {
            try
            {
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [Sheet1$]";

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception ex)
            {
                Console.WriteLine("read excel file exception ,{0}", ex.Message);
                return null;
            }
        }

        public List<string> LoadSheetsNames()
        {
            try
            {
                List<string> nameList = new List<string>();

                string strConn = DBConnectionStr();
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow dr in dt.Rows)
                {
                    if ((string)dr["TABLE_NAME"] != "_xlnm#_FilterDatabase")
                    {
                        nameList.Add((string)dr["TABLE_NAME"]);
                    }
                }
                conn.Close();
                return nameList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string DBConnectionStr()
        {
            //EXCEL 连接字符串
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source="
                + this.filePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1;\"";

            //string strConn;
            //strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";

            return strConn;
        }
    }
}
