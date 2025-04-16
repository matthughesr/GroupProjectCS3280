using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    /// <summary>
    /// This class contains SQL query methods for interacting with the ItemDesc and LineItems tables.
    /// </summary>
    internal class clsItemsSQL
    {
        //- select ItemCode, ItemDesc, Cost from ItemDesc
        //- select distinct(InvoiceNum) from LineItems where ItemCode = 'A'
        //- Update ItemDesc Set ItemDesc = 'abcdef', Cost = 123 where ItemCode = 'A'
        //- Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('ABC', 'blah', 321)
        //- Delete from ItemDesc Where ItemCode = 'ABC'

        /// <summary>
        /// Generates an SQL query to select all items from the ItemDesc table.
        /// </summary>
        /// <returns>A string containing the SQL query.</returns>
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

        /// <summary>
        /// Generates an SQL query to select distinct invoice numbers associated with a specific item code.
        /// </summary>
        /// <param name="sItemCode">The item code to search for in the LineItems table.</param>
        /// <returns>A string containing the SQL query.</returns>
        public string selectItemInvNum(string sItemCode)
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = '" + sItemCode + "'";

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Generates an SQL query to update an item's description and cost in the ItemDesc table.
        /// </summary>
        /// <param name="sItemDescr">The new item description.</param>
        /// <param name="sItemCost">The new item cost.</param>
        /// <param name="sItemCode">The item code to identify the item to update.</param>
        /// <returns>A string containing the SQL query.</returns>
        public string updateItemDescrTable(string sItemDescr, string sItemCost, string sItemCode)
        {
            try
            {
                string sSQL = "Update ItemDesc Set ItemDesc = '" + sItemDescr + "', Cost = " + sItemCost + " where ItemCode = '" + sItemCode + "'";

                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Generates an SQL query to insert a new item into the ItemDesc table.
        /// </summary>
        /// <param name="sItemCode">The item code of the new item.</param>
        /// <param name="sItemDescr">The description of the new item.</param>
        /// <param name="sItemCost">The cost of the new item.</param>
        /// <returns>A string containing the SQL query.</returns>
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

        /// <summary>
        /// Generates an SQL query to delete an item from the ItemDesc table.
        /// </summary>
        /// <param name="sItemCode">The item code of the item to delete.</param>
        /// <returns>A string containing the SQL query.</returns>
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
