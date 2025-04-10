using GroupProject.Common;
using GroupProject.Items;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        clsMainLogic clsMainLogic;
        clsGetItems clsGetItems;

        private List<clsItem> AllItems = new List<clsItem>();  // Holds all items (inventory)
        private ObservableCollection<clsItem> InvoiceItems = new ObservableCollection<clsItem>();  // Holds only invoice items


        /// <summary>
        /// Public property for editing mode
        /// </summary>
        public bool bEditingMode {  get; set; }


        /// <summary>
        /// Public property for invoice total cost 
        /// </summary>
        public float fTotalCost {  get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                clsMainLogic = new clsMainLogic();
                clsGetItems = new clsGetItems();



                cbItems.ItemsSource = clsGetItems.GetAllItems(); //bind combo box to getItems
                dgInvoice.ItemsSource = InvoiceItems;   //bind data grid to show items added

                gbInvoiceInfo.IsEnabled = false;



            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }


        /// <summary>
        /// Opens search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSearchWindow(object sender , RoutedEventArgs e)
        {
            try
            {
                
                wndSearch searchWindow = new wndSearch();

                this.Hide();
                searchWindow.ShowDialog();
                this.Show();
                //check to see if invoice is selected. If so load it up



            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Opens items window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                wndItems itemsWindow = new wndItems();

                this.Hide();
                itemsWindow.ShowDialog();
                this.Show();
                //Refresh items combo box.


            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Combo box for invoice items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsItem SelectedItem = (clsItem)cbItems.SelectedItem;
                string sSelectedItemCost = SelectedItem.sItemCost;

                lblCost.Content = "Cost: $" + sSelectedItemCost;

            //The Items combo box will be refreshed anytime the items window is closed. This will be done by setting it to null and then rebinding the combobox.

            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }
        

        /// <summary>
        /// Create invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bEditingMode = true;
                fTotalCost = 0;
                gbInvoiceInfo.IsEnabled = true;
                lblInvoiceNum.Content = "Invoice Number: TBD";

            // Will remove the current invoice that is being viewed if any
            // Allow user to add items 
            // Allow user to select invoice date
            // Save info to database


            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Edit invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gbInvoiceInfo.IsEnabled = true;
                bEditingMode = true;

                // Put main window into editing mode
                // Allow user to addd items
                // Allow user to edit invoice date
                // Save info to database

            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Save invoice button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bEditingMode = false; //Take main window out of editing mode. 
                gbInvoiceInfo.IsEnabled = false;  // Lock down window so no more changes can be made
                // Save info to database

            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Data grid to display invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            //Invoice ID will be extracted from search window by a public property in the search window
            //


            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Remove item button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Make sure its in editing mode
                // Remove item from datagrid

                clsItem SelectedItem = (clsItem)cbItems.SelectedItem;
                if(InvoiceItems.Contains(SelectedItem))
                {
                    InvoiceItems.Remove(SelectedItem);
                    fTotalCost -= float.Parse(SelectedItem.sItemCost);
                    lblTotalCost.Content = "Total Cost: $" + fTotalCost.ToString();

                }


            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        /// <summary>
        /// Add item button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Make sure its in editing mode
                // Add item to data grid for viewing
                clsItem SelectedItem = (clsItem)cbItems.SelectedItem;
                if (!InvoiceItems.Contains(SelectedItem)) // Avoid duplicates
                {
                    InvoiceItems.Add(SelectedItem);
                    fTotalCost += float.Parse(SelectedItem.sItemCost);
                    lblTotalCost.Content = "Total Cost: $" + fTotalCost.ToString();

                }

            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }






    }
}
