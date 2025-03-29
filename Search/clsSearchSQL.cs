using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls.Primitives;


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

        public static string searchViaInvoiceAndDate(string invoiceNumber, string Date)
        {
            string query = @$"SELECT * FROM Invoices WHERE InvoiceNum = {invoiceNumber} AND InvoiceDate = {Date}";

            return query;

        }

        public static string searchViaInvoiceDateAndCost(string invoiceNumber, string Date, string Cost) 
        {
            string query = @$"SELECT * FROM Invoices WHERE InvoiceNum = {invoiceNumber} AND InvoiceDate = {Date} AND TotalCost = {Cost}";

            return query;

        }

        public static string searchViaCost(string Cost)
        {
            string query = @$"SELECT * FROM Invoices WHERE TotalCost = {Cost}";
            return query;
        }

        public static string searchViaDate(string Date)
        {
            string query = @$"SELECT * From Invoices WHERE InvoiceDate = {Date}";

            return query;
        }
    }
}
