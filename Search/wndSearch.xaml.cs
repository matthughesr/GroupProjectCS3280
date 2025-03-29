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
        public wndSearch()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event listenr for when the search button is clicked for invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButtonInvoice_Click(object sender, RoutedEventArgs e)
        {
            //TODO: BULLET PROOF INVOICE NUMBER DATA
            try
            {

                string invoiceNumber = invoiceNumberTextBox.Text;

                List<clsInvoice> invoiceList = clsSearchLogic.searchViaInvoice(invoiceNumber);

                searchResultsCombo.ItemsSource = invoiceList;
                searchResultsCombo.SelectedIndex = 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// Event listener for when the cancel button is pressed. Closes search window and opens main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButtonInvoice_Click(object sender, RoutedEventArgs e ) 
        {
            //wndMain newWindow = new wndMain(); // I commented these lines out so we don't get additional main windows when you close the search window. -- Matt
            //newWindow.Show();

            this.Close();
        }

        private void viewInvoiceInMain(object sender, SelectionChangedEventArgs e)
        {
            // Once selection is made pass list to main window for viewing
        }

    }
}
