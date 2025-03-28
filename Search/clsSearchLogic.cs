using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Data;

/// ALL BUSINESS LOGIC BEHIND SEARCHING THE DATABASES AND RETURNING VALUES
namespace GroupProject.Search
{
    internal class clsSearchLogic
    {

        /// <summary>
        /// Method that returns all values related to an invoice
        /// </summary>
        /// <param name="invoiceNumber"> INT Invoice Number to search the database</param>
        /// <returns></returns>
        public static List<clsInvoice> searchViaInvoice(string invoiceNumber)
        {
            try
            {
            List<clsInvoice> invoiceFields = new List<clsInvoice>();

            clsDataAccess db = new clsDataAccess();
            int iRet = 0;

            string sqlQuery = clsSearchSQL.searchViaInvoice(invoiceNumber);

            DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);

            for (int i = 0; i < iRet ; i++) 
            {
                clsInvoice invoiceItems = new clsInvoice
                {
                    invoiceNumber = ds.Tables[0].Rows[i]["invoiceNum"].ToString(),
                    invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
                    totalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString(),
                };

                invoiceFields.Add(invoiceItems);
            }

            return invoiceFields;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {

                // throw;
            }
        }
    }


}
