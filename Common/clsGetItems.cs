using GroupProject.Main;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace GroupProject.Common
{
    internal class clsGetItems
    {
        //getallitems. reutrn list. Used to populate combo box. Can be seperate cls
        public List<clsItem> GetAllItems()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet(); //Holds the return values
                int iRet = 0;   //Number of return values
                List<clsItem> items = new List<clsItem>();

                string sSQL= clsMainSQL.SelectAllItem();        //get sql statement
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);       //Execute statement

                //it will return data set. Loop thorugh , for each row create a new clsIem, fill it up , add list of items

                for (int i = 0; i < iRet; i++)
                {
                    clsItem item = new clsItem();

                    item.sItemCode = ds.Tables[0].Rows[i][0].ToString();
                    item.sItemDescription = ds.Tables[0].Rows[i][1].ToString();
                    item.sItemCost = ds.Tables[0].Rows[i][2].ToString();

                    items.Add(item);
                    
                }
                return items;

            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        } 
    }
}
