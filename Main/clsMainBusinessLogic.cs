using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject.Main
{
    class clsMainBusinessLogic
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
    }



}
