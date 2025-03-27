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
                    lineItemNum = ds.Tables[0].Rows[i]["LineItemNum"].ToString()
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

        /// <summary>
        /// Method that returns all values related to an item code
        /// </summary>
        /// <param name="invoiceNumber"> STRING Item code to search the database</param>
        /// <returns></returns>
        public static List<clsItemCode> searchViaItemCode(string itemCode)
        {
            try
            {
                List<clsItemCode> itemCodeFields = new List<clsItemCode>();

                clsDataAccess db = new clsDataAccess();
                int iRet = 0;

                string sqlQuery = clsSearchSQL.searchViaItemCode(itemCode);

                DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsItemCode itemCodeItems = new clsItemCode
                    {
                        itemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString(),
                        lineItemNum = ds.Tables[0].Rows[i]["LineItemNum"].ToString(),
                        itemDesc = ds.Tables[0].Rows[i]["ItemDesc"].ToString(),
                        cost = ds.Tables[0].Rows[i]["Cost"].ToString()
                    };

                    itemCodeFields.Add(itemCodeItems);
                }


                return itemCodeFields;
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
