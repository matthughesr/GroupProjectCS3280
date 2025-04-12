using GroupProject.Common;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        /// Method to edit invoice and save new invoice
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        //public void EditInvoice(clsOldInvoice, clsNewinvoice)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        //}

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

                string sSQL = clsMainSQL.SelectLineItems(sInvoiceNum);
                ds = db.ExecuteSQLStatement(sSQL, ref iRet); // Execute SQL statement

                GroupProject.Common.clsInvoice invoice = new GroupProject.Common.clsInvoice
                {
                    Items = new ObservableCollection<clsItem>()
                };

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