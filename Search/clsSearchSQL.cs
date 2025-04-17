using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls.Primitives;
using System.Reflection;


/// CONTAINS ALL SQL STATEMENTS RELATED TO SEARCHING THE DATABASE
namespace GroupProject.Search
{
    public class clsSearchSQL
    {

        public clsSearchSQL()
        {
        
        }

        /// <summary>
        /// A method that returns the query for all values from the invoices table
        /// </summary>
        /// <returns></returns>
        public static string viewInvoices()
        {
            string query = "SELECT * " +
                           "FROM Invoices";
            return query;
        }

        /// <summary>
        /// A method that returns the query for all values from the Item Description table
        /// </summary>
        /// <returns></returns>
        public static string viewItemDesc()
        {
            string query = "SELECT * " +
                           "FROM ItemDesc";
            return query;
        }

        /// <summary>
        /// A method that retunrs the query for all values from the Line Items table
        /// </summary>
        /// <returns></returns>
        public static string viewLineItems()
        {
            string query = "SELECT * " +
                           "FROM LineItems";
            return query;
        }

        /// <summary>
        /// A method that returns the query for a search for all values pertaining to an invoice number
        /// </summary>
        /// <param name="invoiceNumber"> STRING </param>
        /// <returns></returns> 
        public static string searchViaInvoice(string invoiceNumber)
        {
            string query = @$"SELECT * 
                           FROM Invoices i 
                           WHERE i.InvoiceNum = {invoiceNumber}";

            return query;
        }
        /// <summary>
        /// A method the returns data via Invoice and Date
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static string searchViaInvoiceAndDate(string invoiceNumber, string Date)
        {
            string query = @$"SELECT * FROM Invoices WHERE InvoiceNum = {invoiceNumber} AND InvoiceDate = {Date}";

            return query;

        }
        /// <summary>
        /// Method that returns a query based on Date and Cost
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="Date"></param>
        /// <param name="Cost"></param>
        /// <returns></returns>
        public static string searchViaInvoiceDateAndCost(string invoiceNumber, string Date, string Cost) 
        {
            string query = @$"SELECT * FROM Invoices WHERE InvoiceNum = {invoiceNumber} AND InvoiceDate = {Date} AND TotalCost = {Cost}";

            return query;

        }
        /// <summary>
        /// Method that returns a query based on cost
        /// </summary>
        /// <param name="Cost"></param>
        /// <returns></returns>
        public static string searchViaCost()
        {
            string query = @$"SELECT DISTINCT i.TotalCost FROM Invoices i";
            return query;
        }
        /// <summary>
        /// Method that returns a query based on date
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static string searchViaDate()
        {
            string query = @$"SELECT DISTINCT i.InvoiceDate From Invoices i";

            return query;
        }

        /// <summary>
        /// Function that returns a SQL query based on the selected filters
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceCost"></param>
        /// <returns></returns>
        public static string searchViaFilters(string invoiceNumber = null, string invoiceDate = null, string invoiceCost = null)
        {
            try
            {
                string baseQuery = "SELECT * FROM Invoices";
                List<string> filters = new List<string>();

                if (!string.IsNullOrEmpty(invoiceNumber))
                    filters.Add($"InvoiceNum = {invoiceNumber}");

                if (!string.IsNullOrEmpty(invoiceDate))
                    filters.Add($"InvoiceDate = #{invoiceDate}#");

                if (!string.IsNullOrEmpty(invoiceCost))
                    filters.Add($"TotalCost = {invoiceCost}");

                if (filters.Count > 0)
                {
                    baseQuery += " WHERE " + string.Join(" AND ", filters);
                }

                return baseQuery;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
