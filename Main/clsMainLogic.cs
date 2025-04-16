using GroupProject.Common;
using GroupProject.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Documents;

namespace GroupProject.Main
{
    class clsMainLogic
    {


    /// <summary>
    /// Method to handle exceptions
    /// </summary>
    /// <param name="sClass"></param>
    /// <param name="sMethod"></param>
    /// <param name="sMessage"></param>
    public static void HandleError(string sClass, string sMethod, string sMessage)
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
        
        
        /// <summary>
        /// Method to save a new invoice 
        /// </summary>
        /// <param name=""></param>
        /// <exception cref="Exception"></exception>
        public void SaveInvoice(GroupProject.Common.clsInvoice invoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet(); //Holds the return values
                int iRet = 0;   //Number of return values


                string sSQL = clsMainSQL.InsertInvoices(invoice.sInvoiceDate, invoice.sTotalCost);
                db.ExecuteNonQuery(sSQL);  //Execute sql insert statement

                sSQL = "SELECT MAX(InvoiceNum) FROM Invoices";
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);  //Execute sql statement
                invoice.sInvoiceNum = ds.Tables[0].Rows[0][0].ToString();

                //make sure to get all items 
                int iLineItemNum = 0;
                foreach (var item in invoice.Items)
                    {
                        sSQL = clsMainSQL.InsertLineItems(invoice.sInvoiceNum, iLineItemNum.ToString(), item.sItemCode);
                        db.ExecuteNonQuery(sSQL);  //Execute sql insert statement
                        iLineItemNum++;

                    }
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        }


        /// <summary>
        /// Method to edit invoice and save it
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public void EditInvoice(GroupProject.Common.clsInvoice invoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet(); //Holds the return values
                int iRet = 0;   //Number of return values

                string sSQL = clsMainSQL.UpdateInvoices(invoice.sInvoiceNum, invoice.sTotalCost); //Update total cost
                db.ExecuteNonQuery(sSQL);  //Execute sql update statement 

                //update line items 
                sSQL = clsMainSQL .DeleteLineItemsByInvoice(invoice.sInvoiceNum);   //delete old items
                db.ExecuteNonQuery(sSQL);  //Execute sql delete statement


                //make sure to get all items 
                int iLineItemNum = 0;
                foreach (var item in invoice.Items)
                {
                    sSQL = clsMainSQL.InsertLineItems(invoice.sInvoiceNum, iLineItemNum.ToString(), item.sItemCode);
                    db.ExecuteNonQuery(sSQL);  //Execute sql insert statement
                    iLineItemNum++;

                }



                //Once the Invoice is saved, query the max invoice number from the database, to display for the invoice number(for our project, this will work, since the last inserted invoice, will be the max).
                //lock down controls for when editing and creating invoice. 
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        }

        /// <summary>
        /// Gets the invoice and the items for the selected invoice from search window
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public GroupProject.Common.clsInvoice GetInvoice(string sInvoiceNum)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet(); // Holds the return values
                int iRet = 0; // Number of return values


                string sSQL = clsMainSQL.SelectInvoiceByNumber(sInvoiceNum);
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                GroupProject.Common.clsInvoice invoice = new GroupProject.Common.clsInvoice
                {
                    sInvoiceNum = sInvoiceNum, // This might not be set correctly
                    sInvoiceDate = ds.Tables[0].Rows[0][1].ToString(),
                    sTotalCost = ds.Tables[0].Rows[0][2].ToString(),
                    Items = new ObservableCollection<clsItem>()
                };


                sSQL = clsMainSQL.SelectLineItems(sInvoiceNum);
                ds = db.ExecuteSQLStatement(sSQL, ref iRet); // Execute SQL statement


                for (int i = 0; i < iRet; i++)
                {
                    clsItem item = new clsItem
                    {
                        sItemCode = ds.Tables[0].Rows[i][0].ToString(),
                        sItemDescription = ds.Tables[0].Rows[i][1].ToString(),
                        sItemCost = ds.Tables[0].Rows[i][2].ToString()
                    };
                    invoice.Items.Add(item);
                }

                return invoice; // Return the invoice object
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Gets the invoice number for most recently created invoice
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string getInvoiceNum()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet(); // Holds the return values
                int iRet = 0; // Number of return values
                string sSQL = "SELECT MAX(InvoiceNum) FROM Invoices";
                ds = db.ExecuteSQLStatement(sSQL, ref iRet); // Execute SQL statement
                return ds.Tables[0].Rows[0][0].ToString(); // Return the invoice number
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        // Have methods to execute sql statements
























    }



}








/*
 
          try
            {

            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);}




      



            try
            {
              


            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }



 
 
 */