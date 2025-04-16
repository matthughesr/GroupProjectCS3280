using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    class clsMainSQL
    {

        /// <summary>
        /// Updates the Invoices table with the total cost
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <param name="sTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string UpdateInvoices(string sInvoiceNum, string sTotalCost)
        {
            try
            {
                string sSQL = "UPDATE Invoices SET TotalCost = " + sTotalCost.Replace(",", "") + " WHERE InvoiceNum = " + sInvoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        }
        /// <summary>
        /// Inserts InvoiceNum, LineItemNum, ItemCode into LineItems table
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <param name="sLineItemNum"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InsertLineItems(string sInvoiceNum, string sLineItemNum, string sItemCode)
    {
            try
            {
                string sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values (" + sInvoiceNum + "," + sLineItemNum + ",'" + sItemCode + "')";

                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

       }


        /// <summary>
        /// Inserts InvoiceDate and TotalCost into Invoices table
        /// </summary>
        /// <param name="sInvoiceDate"></param>
        /// <param name="sTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InsertInvoices(string sInvoiceDate, string sTotalCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) VALUES (#" + DateTime.Parse(sInvoiceDate).ToString("MM/dd/yyyy") + "#, " + sTotalCost.Replace(",", "") + ")";

                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        }

        /// <summary>
        /// Selects invoice by number. This is used to get the invoice number, date, and total cost
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceByNumber(string sInvoiceNum)
        {
            try
            {
                string sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + sInvoiceNum;

                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        }

        /// <summary>
        /// Selects all items from ItemDesc table
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectAllItem()
        {
            try
            {
                string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";

                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        }

        /// <summary>
        /// Selects  LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectLineItems(string sInvoiceNum)
        {
            try
            {
                string sSQL = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                              "FROM LineItems, ItemDesc " +
                              "WHERE LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = " + sInvoiceNum;

                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        }

        /// <summary>
        /// Deletes Line items by invoice number
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string DeleteLineItemsByInvoice(string sInvoiceNum)
        {
            try
            {
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + sInvoiceNum;

                return sSQL;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        }




    }


}


/*
- UPDATE Invoices SET TotalCost = 1200 WHERE InvoiceNum = 123
- INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values (123, 1, 'AA')
- INSERT INTO Invoices (InvoiceDate, TotalCost) Values (#4/13/2018#, 100)
- SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 123
- select ItemCode, ItemDesc, Cost from ItemDesc
- SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = 5000
- DELETE FROM LineItems WHERE InvoiceNum = 5000
*/




