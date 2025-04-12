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
        /// Function that returns all invoices in database
        /// </summary>
        /// <returns></returns>
        public static List<clsInvoice> getInvoices()
        {
            try
            {
                List<clsInvoice> invoiceList = new List<clsInvoice>();
                clsDataAccess db = new clsDataAccess();

                int iRet = 0;

                string sqlQuery = clsSearchSQL.viewInvoices();

                DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);


                for (int i = 0; i < iRet; i++)
                {
                    clsInvoice invoiceItems = new clsInvoice
                    {
                        invoiceNumber = ds.Tables[0].Rows[i]["invoiceNum"].ToString(),
                        invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
                        totalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString(),
                    };

                    invoiceList.Add(invoiceItems);
                }

                return invoiceList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Function that only returns the invoice numbers
        /// </summary>
        /// <returns></returns>
        public static List<clsInvoice> getInvoiceNumbers()
        {
            try
            {
                List<clsInvoice> invoiceList = new List<clsInvoice>();
                clsDataAccess db = new clsDataAccess();

                int iRet = 0;

                string sqlQuery = clsSearchSQL.viewInvoices();

                DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsInvoice invoiceItems = new clsInvoice
                    {
                        invoiceNumber = ds.Tables[0].Rows[i]["invoiceNum"].ToString()
                    };

                    invoiceList.Add(invoiceItems);
                }

                return invoiceList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Function that only returns the invoice date
        /// </summary>
        /// <returns></returns>
        public static List<clsInvoice> getInvoiceDate()
        {
            try
            {
                List<clsInvoice> invoiceList = new List<clsInvoice>();
                clsDataAccess db = new clsDataAccess();

                int iRet = 0;

                string sqlQuery = clsSearchSQL.viewInvoices();

                DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsInvoice invoiceItems = new clsInvoice
                    {
                        invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
                    };

                    invoiceList.Add(invoiceItems);
                }

                return invoiceList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Function that only returns the invoice cost
        /// </summary>
        /// <returns></returns>
        public static List<clsInvoice> getInvoiceCost()
        {
            try
            {
                List<clsInvoice> invoiceList = new List<clsInvoice>();
                clsDataAccess db = new clsDataAccess();

                int iRet = 0;

                string sqlQuery = clsSearchSQL.viewInvoices();

                DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsInvoice invoiceItems = new clsInvoice
                    {
                        totalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString(),
                    };

                    invoiceList.Add(invoiceItems);
                }

                return invoiceList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<clsInvoice> searchViaFilters(string invoiceNumber = null, string invoiceDate = null, string invoiceCost = null)
        {
            try
            {
                List<clsInvoice> invoiceList = new List<clsInvoice>();
                clsDataAccess db = new clsDataAccess();

                int iRet = 0;

                string sqlQuery = clsSearchSQL.searchViaFilters(invoiceNumber, invoiceDate, invoiceCost);

                DataSet ds = db.ExecuteSQLStatement(sqlQuery, ref iRet);


                for (int i = 0; i < iRet; i++)
                {
                    clsInvoice invoiceItems = new clsInvoice
                    {
                        invoiceNumber = ds.Tables[0].Rows[i]["invoiceNum"].ToString(),
                        invoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
                        totalCost = ds.Tables[0].Rows[i]["TotalCost"].ToString(),
                    };

                    invoiceList.Add(invoiceItems);
                }

                return invoiceList;
            }
            catch (Exception)
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
