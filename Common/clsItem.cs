using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Common
{
    /// <summary>
    /// This class represents an item object
    /// </summary>
    internal class clsItem
    {
        /// <summary>
        /// Public property for item code
        /// </summary>
        public string sItemCode { get; set; }

        /// <summary>
        /// Public property for Item Description
        /// </summary>
        public string sItemDescription { get; set; }    


        /// <summary>
        /// public property for item cost
        /// </summary>
        public string sItemCost { get; set; }


        public override string ToString()
        {
            try
            {
                return sItemDescription;

            }
            catch (Exception ex)
            { throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message); }
        }
    }
}
