using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    internal class clsInvoice
    {

        public string invoiceNumber { get; set; }
        public string invoiceDate { get; set; }
        public string totalCost { get; set; }

        public override string ToString()
        {
            return $"NUMBER: {invoiceNumber}, DATE: {invoiceDate}, COST: {totalCost}";
        }

    }
}
