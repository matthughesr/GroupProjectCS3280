using GroupProject.Common;
using GroupProject.Search;
using System;
using System.Collections.Generic;
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

                string sSQL = clsMainSQL.InsertInvoices(invoice.sInvoiceDate, invoice.sTotalCost);
                db.ExecuteNonQuery(sSQL);  //Execute sql insert statement


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
        
        /*
        /// <summary>
        /// Method to edit invoice and save new invoice
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public void EditInvoice(clsOldInvoice, clsNewinvoice)
        {
            try
            {

            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        }

        /// <summary>
        /// Gets the invoice and the items for the selected invoice from search window
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> GetInvoice()
        {
            try
            {
                List<clsInvoice> Invoice = new List<clsInvoice>();
                return Invoice;
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        }
        */

        

       

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