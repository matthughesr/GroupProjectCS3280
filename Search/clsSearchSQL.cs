using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// CONTAINS ALL SQL STATEMENTS RELATED TO SEARCHING THE DATABASE
namespace GroupProject.Search
{
    public class clsSearchSQL
    {

        public clsSearchSQL()
        {
        
        }

        public string invoiceNumber { get; set; }
        public string invoiceDate { get; set; }
        public string totalCost { get; set; }
        public string lineItemNum { get; set; }
        public string itemDesc { get; set; }
        public string cost { get; set; }

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
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public static string searchViaInvoice(string invoiceNumber)
        {
            string query = @$"SELECT i.invoiceNum, i.InvoiceDate, i.TotalCost, li.LineItemNum 
                           FROM Invoices i 
                           INNER JOIN LineItems li ON i.InvoiceNum = li.InvoiceNum 
                           WHERE i.InvoiceNum = {invoiceNumber}";

            return query;
        }

        /// <summary>
        /// A method that returns the query for a search for all values pertaining to an item code
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static string searchViaItemCode(string itemCode)
        {
            string query = @$"SELECT li.ItemCode, li.LineItemNum, id.ItemDesc, id.Cost 
                              FROM LineItems li 
                              INNER JOIN ItemDesc id ON li.ItemCode = id.ItemCode
                              WHERE li.ItemCode = {itemCode}";

            return query;
        }
    }
}
