using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Common
{
    internal class clsInvoice
    {
        /// <summary>
        /// Public property for invoice number
        /// </summary>
        public string sInvoiceNum {  get; set; }

        /// <summary>
        /// Public Property for invoice number
        /// </summary>
        public string sInvoiceDate { get; set; }

        /// <summary>
        /// Public property for invoice total cost
        /// </summary>
        public string sTotalCost { get; set; }

        /// <summary>
        /// public property of all items on invoice 
        /// </summary>
        public List<clsInvoice> Items { get; set; }
    }
}
