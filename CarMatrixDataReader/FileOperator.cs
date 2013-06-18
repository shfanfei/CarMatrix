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
        private DataSet dataset;
        private List<string> nameList;

        public DataSet DataSet
        {
            get
            {
                return this.dataset;
            }
        }

        public IEnumerable<string> TableNames
        {
            get
            {
                return this.nameList;
            }
        }

        public FileOperator(string filePath)
        {
            this.filePath = filePath;
            this.strConn = DBConnectionStr();
        }

        public void LoadExcelData()
        {
            try
            {
                this.dataset = new DataSet();
                this.nameList = new List<string>();

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

                foreach (var name in nameList)
                {
                    string sql = string.Format("SELECT * FROM  [{0}]", name);
                    OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, conn);
                    OleDaExcel.Fill(this.dataset, name);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string DBConnectionStr()
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source="
                + this.filePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1;\"";

            return strConn;
        }
    }
}
