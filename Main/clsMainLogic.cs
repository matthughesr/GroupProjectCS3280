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
        /*
        
        /// <summary>
        /// Method to save a new invoice 
        /// </summary>
        /// <param name=""></param>
        /// <exception cref="Exception"></exception>
        public void SaveInvoice(clsInvoice)
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet(); //Holds the return values
                int iRet = 0;   //Number of return values

                string sSQL = clsMainSQL.InsertInvoices(sInvoiceDate, sTotalCost);
                db.ExecuteNonQuery(sSQL);  //Execute sql insert statement


            //make sure to get all items 
                sSQL = clsMainSQL.InsertLineItems(InvoiceNum, LineItemNum, ItemCode);
                db.ExecuteNonQuery(sSQL);  //Execute sql insert statement
            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }

        }


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