using GroupProject.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Public value for the selected invoice for MAIN to access
        /// </summary>
        public clsInvoice SelectedInvoice { get; private set; }

        public wndSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Function that runs once the form has loaded. Initializes the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wndSearch_Load(object sender, EventArgs e)
        {
            // Populate the data grid
            List<clsInvoice> invoiceList = new List<clsInvoice>();
            invoiceList = clsSearchLogic.getInvoices();

            dgInvoice.ItemsSource = invoiceList;

            // Populate the Invoice Number Combo Box
            List<clsInvoice> invoiceNumber = new List<clsInvoice>();
            invoiceNumber = clsSearchLogic.getInvoiceNumbers();

            invoiceNumberCB.ItemsSource = invoiceNumber;

            // Populate the Invoice Date Combo Box
            List<clsInvoice> invoiceDate = new List<clsInvoice>();
            invoiceDate = clsSearchLogic.getInvoiceDate();

            invoiceDateCB.ItemsSource = invoiceDate;
            // Populate the Total Cost Combo Box
            List<clsInvoice> invoiceCost = new List<clsInvoice>();
            invoiceCost = clsSearchLogic.getInvoiceCost();

            invoiceCostCB.ItemsSource = invoiceCost;
        }

        /// <summary>
        /// Event listener for when the cancel button is pressed. Closes search window and opens main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButtonInvoice_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        /// <summary>
        /// Function that selects filters and pulls search results from the DB using these filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchViaFilters(object sender, SelectionChangedEventArgs e)
        {
            string invoiceNumber = invoiceNumberCB.SelectedItem?.ToString();
            string invoiceDate = invoiceDateCB.SelectedItem?.ToString();
            string invoiceCost = invoiceCostCB.SelectedItem?.ToString();

            List<clsInvoice> clsInvoiceSearchViaFilters = new List<clsInvoice>();
            clsInvoiceSearchViaFilters = clsSearchLogic.searchViaFilters(invoiceNumber, invoiceDate, invoiceCost);

            dgInvoice.ItemsSource = clsInvoiceSearchViaFilters;
        }

        /// <summary>
        /// Function that clears all selected filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearFilters(object sender, RoutedEventArgs e)
        {
            try
            {
                invoiceNumberCB.SelectedIndex = -1;
                invoiceDateCB.SelectedIndex = -1;
                invoiceCostCB.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Event listener for when an invoice has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceSelected(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedInvoice = dgInvoice.SelectedItem as clsInvoice;

                if (selectedInvoice != null)
                {

                    SelectedInvoice = selectedInvoice;
                   // MessageBox.Show("Success! Invoice Selected");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select a row first.");
                }

                
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Error Handler
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
