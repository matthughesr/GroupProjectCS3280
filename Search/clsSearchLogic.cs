using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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

                string sqlQuery = clsSearchSQL.searchViaDate();

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
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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

                string sqlQuery = clsSearchSQL.searchViaCost();

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
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// Function that executes a SQl query based on the filters selected in the search window
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceCost"></param>
        /// <returns></returns>
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
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); 
            }
        }

    }


}
