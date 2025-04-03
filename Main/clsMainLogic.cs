using System;
using System.Collections.Generic;
using System.Linq;
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


        //getallitems. reutrn list. Used to populate combo box. Can be seperate cls
        
        //saveinvoice(clsInvoice)

        //Editinvoijce(clsOldInvoice, clsNewinvoice)

        //get incoie(invoicenum) reutrns clsinvocie-- get the inovice and the items for the sleected invoice from serach window



       

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