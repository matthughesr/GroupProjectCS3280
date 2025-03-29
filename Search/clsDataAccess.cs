using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System.Reflection;

namespace GroupProject.Search
{
    public class clsDataAccess
    {
        string sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\GroupProjectInvoice.accdb";

        public DataSet ExecuteSQLStatement(string sSQL, ref int iRecordCount)
        {
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(sConnectionString);
            OleDbDataAdapter da = new OleDbDataAdapter(sSQL, conn);

            iRecordCount = da.Fill(ds);
            return ds;
        }

        public int ExecuteNonQuery(string sSQL)
        {
            OleDbConnection conn = new OleDbConnection(sConnectionString);
            OleDbCommand cmd = new OleDbCommand(sSQL, conn);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            return rows;
        }
    }
}

