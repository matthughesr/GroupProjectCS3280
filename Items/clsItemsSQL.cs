using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    internal class clsItemsSQL
    {

        //- select ItemCode, ItemDesc, Cost from ItemDesc
        //- select distinct(InvoiceNum) from LineItems where ItemCode = 'A'
        //- Update ItemDesc Set ItemDesc = 'abcdef', Cost = 123 where ItemCode = 'A'
        //- Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('ABC', 'blah', 321)
        //- Delete from ItemDesc Where ItemCode = 'ABC'

        public string selectAllItemsDescrTable()
        {
            try
            {
                string sSQL = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        public string selectItemInvNum(string sItemCode)
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = '" + sItemCode + "'" ;

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        public string updateItemDescrTable(string sItemDescr, string sItemCost, string sItemCode)
        {
            try
            {
                string sSQL = "Update ItemDesc Set ItemDesc = '" + sItemDescr +"', Cost = " + sItemCost + " where ItemCode = '" + sItemCode + "'";

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        public string insertIntoItemDescrTable(string sItemCode, string sItemDescr, string sItemCost)
        {
            try
            {
                string sSQL = "Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('" + sItemCode + "', '" + sItemDescr + "', " + sItemCost + ")";

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        public string deleteItemDescrTable(string sItemCode)
        {
            try
            {
                string sSQL = "Delete from ItemDesc Where ItemCode = '" + sItemCode + "'";

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
