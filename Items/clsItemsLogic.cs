using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using GroupProject.Search;
using System.Data;
using GroupProject.Common;
using System.Reflection;

namespace GroupProject.Items
{
    internal class clsItemsLogic
    {
        // GetAllItems returns List<clsItem>
        // AddItem(clsItem)
        // EditItem(clsItem clsOldItem, clsItem clsNewItem)
        // DeleteItem(clsItem clsItemDelete)
        // IsItemInInvoice(clsItem)

        /// <summary>
        /// Retrieves all items from the database.
        /// </summary>
        /// <returns>List of clsItem</returns>
        public static List<clsItem> RetrieveAllItems()
        {
            try
            {
                // Create an instance of clsItemsSQL to get the SQL query
                clsItemsSQL sSQL = new clsItemsSQL();
                string query = sSQL.selectAllItemsDescrTable();

                // Execute the query using clsDataAccess
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(query, ref iRet);

                // Populate the list of items
                List<clsItem> items = new List<clsItem>();
                for (int i = 0; i < iRet; i++)
                {
                    clsItem item = new clsItem
                    {
                        sItemCode = ds.Tables[0].Rows[i]["ItemCode"].ToString(),
                        sItemDescription = ds.Tables[0].Rows[i]["ItemDesc"].ToString(),
                        sItemCost = ds.Tables[0].Rows[i]["Cost"].ToString()
                    };

                    items.Add(item);
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Adds a new item to the database.
        /// </summary>
        /// <param name="newItem">The item to be added.</param>
        public static void AddItem(clsItem newItem)
        {
            try
            {
                // Create an instance of clsItemsSQL to get the SQL query
                clsItemsSQL sSQL = new clsItemsSQL();
                string query = sSQL.insertIntoItemDescrTable(newItem.sItemCode, newItem.sItemDescription, newItem.sItemCost);

                // Execute the query using clsDataAccess
                clsDataAccess db = new clsDataAccess();
                int rowsAffected = db.ExecuteNonQuery(query);

                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were affected. The item might already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Edits an existing item in the database.
        /// </summary>
        /// <param name="oldItem">The original item before changes.</param>
        /// <param name="newItem">The updated item with new values.</param>
        public static void EditItem(clsItem oldItem, clsItem newItem)
        {
            try
            {
                // Create an instance of clsItemsSQL to get the SQL query
                clsItemsSQL sSQL = new clsItemsSQL();
                string query = sSQL.updateItemDescrTable(newItem.sItemDescription, newItem.sItemCost, oldItem.sItemCode);

                // Execute the query using clsDataAccess
                clsDataAccess db = new clsDataAccess();
                int rowsAffected = db.ExecuteNonQuery(query);

                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were affected. The item might not exist or no changes were made.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the list of invoice numbers associated with the given item code.
        /// </summary>
        /// <param name="itemCode">The item code to check.</param>
        /// <returns>A list of invoice numbers.</returns>
        public static List<string> GetItemInvoiceNumbers(string itemCode)
        {
            try
            {
                // Create an instance of clsItemsSQL to get the SQL query
                clsItemsSQL sSQL = new clsItemsSQL();
                string query = sSQL.selectItemInvNum(itemCode);

                // Execute the query using clsDataAccess
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(query, ref iRet);

                // Extract invoice numbers from the result
                List<string> invoiceNumbers = new List<string>();
                for (int i = 0; i < iRet; i++)
                {
                    invoiceNumbers.Add(ds.Tables[0].Rows[i]["InvoiceNum"].ToString());
                }

                return invoiceNumbers;
            }
            catch (Exception ex)
            {
                throw new Exception("clsItemsLogic.GetItemInvoiceNumbers -> " + ex.Message);
            }
        }


        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="itemToDelete">The item to be deleted.</param>
        public static void DeleteItem(clsItem itemToDelete)
        {
            try
            {
                // Create an instance of clsItemsSQL to get the SQL query
                clsItemsSQL sSQL = new clsItemsSQL();
                string query = sSQL.deleteItemDescrTable(itemToDelete.sItemCode);

                // Execute the query using clsDataAccess
                clsDataAccess db = new clsDataAccess();
                int rowsAffected = db.ExecuteNonQuery(query);

                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were affected. The item might not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsItemsLogic.DeleteItem -> " + ex.Message);
            }
        }
        /// <summary>
        /// Checks if an item is associated with any invoices.
        /// </summary>
        /// <param name="itemCode">The item code to check.</param>
        /// <returns>True if the item is in an invoice, otherwise false.</returns>
        public static bool IsItemInInvoice(string itemCode)
        {
            try
            {
                // Create an instance of clsItemsSQL to get the SQL query
                clsItemsSQL sSQL = new clsItemsSQL();
                string query = sSQL.selectItemInvNum(itemCode);

                // Execute the query using clsDataAccess
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(query, ref iRet);

                // If any rows are returned, the item is in an invoice
                return iRet > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("clsItemsLogic.IsItemInInvoice -> " + ex.Message);
            }
        }
    }
}
