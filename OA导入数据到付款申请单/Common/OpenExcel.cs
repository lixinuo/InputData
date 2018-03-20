using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace InputData.Common
{
    public class OpenExcel
    {
        public static DataSet GetData()
        {
            //打开文件
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.Cancel) return null;

            //判断文件后缀
            var path = file.FileName;
            string fileSuffix = System.IO.Path.GetExtension(path);
            if (string.IsNullOrEmpty(fileSuffix)) return null;

            using (DataSet ds = new DataSet())
            {
                //判断Excel文件是03还是07版本
                string connString = "";
                if (fileSuffix == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                }
                else
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
                }
                //读取文件
                string sqlString = "select * from [Sheet1$]";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    using (OleDbDataAdapter cmd = new OleDbDataAdapter(sqlString, conn))
                    {
                        conn.Open();
                        cmd.Fill(ds);
                        conn.Close();
                        conn.Dispose();
                    }
                    if (ds == null || ds.Tables.Count <= 0) return null;
                    return ds;
                }
            }
        }

    }
}
