using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class clsInvoice
    {

        public string invoiceNumber { get; set; }
        public string invoiceDate { get; set; }
        public string totalCost { get; set; }

        public override string ToString()
        {
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(invoiceNumber))
                parts.Add($"{invoiceNumber}");

            if (!string.IsNullOrEmpty(invoiceDate))
                parts.Add($"{invoiceDate}");

            if (!string.IsNullOrEmpty(totalCost))
                parts.Add($"{totalCost}");

            return string.Join(", ", parts);
        }

    }
}