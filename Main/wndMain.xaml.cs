using GroupProject.Common;
using GroupProject.Items;
using GroupProject.Main;
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
        GroupProject.Common.clsInvoice Invoice;

        private List<clsItem> AllItems = new List<clsItem>();  // Holds all items (inventory)
        //private ObservableCollection<clsItem> InvoiceItems = new ObservableCollection<clsItem>();  // Holds only invoice items



        /// <summary>
        /// Public property for editing mode
        /// </summary>
        public bool bEditingMode {  get; set; }

        /// <summary>
        /// Public Property for creation mode
        /// </summary>
        public bool bCreateInvoiceMode { get; set; } 


        /// <summary>
        /// Public property for invoice total cost 
        /// </summary>
        public float fTotalCost {  get; set; }

        /// <summary>
        /// Public property for selected invoice number
        /// </summary>
        public string sSelectedInvoiceNum { get; set; } // Holds the selected invoice number from the search window
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
                Invoice = new GroupProject.Common.clsInvoice();
                {
                    Invoice.Items = new ObservableCollection<clsItem>(); //Initalize the items property 
                }




                cbItems.ItemsSource = clsGetItems.GetAllItems(); //bind combo box to getItems
                //dgInvoice.ItemsSource = InvoiceItems;   //bind data grid to show items added
                dgInvoice.ItemsSource = Invoice.Items;   //bind data grid to show items added

                gbInvoiceInfo.IsEnabled = false;    //Disable group box controls 
                btnSaveInvoice.IsEnabled = false; // Disable save button until editing or creating an invoice
                btnEditInvoice.IsEnabled = false; // Disable edit button until an invoice is selected
                btnCancel.IsEnabled = false; // Disable cancel button 



            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }


        /// <summary>
        /// Opens search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSearchWindow(object sender, RoutedEventArgs e)
        {
            try
            {
                lblMessage.Content = "";    //reset message label
                lblMessage.Background = System.Windows.Media.Brushes.Transparent;   //reset message label background color



                wndSearch searchWindow = new wndSearch();

                this.Hide();
                searchWindow.ShowDialog();
                this.Show();

                if (searchWindow.SelectedInvoice != null)
                {
                    sSelectedInvoiceNum = searchWindow.SelectedInvoice.invoiceNumber;
                    LoadSelectedInvoice(); // Load the selected invoice
                }


                }
            catch (Exception ex)
            {
                clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
                lblMessage.Content = "";    //reset message label
                lblMessage.Background = System.Windows.Media.Brushes.Transparent;   //reset message label background color

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
                lblMessage.Content = "";    //reset message label
                lblMessage.Background = System.Windows.Media.Brushes.Transparent;   //reset message label background color
                btnSaveInvoice.IsEnabled = true; // Enable save button
                menuBar.IsEnabled = false; // Disable menu bar
                btnEditInvoice.IsEnabled = false; // Disable edit button
                btnCreateInvoice.IsEnabled = false; // Disable create invoice button
                btnCancel.IsEnabled = true; // Enable cancel button

                bCreateInvoiceMode = true;
                fTotalCost = 0;
                gbInvoiceInfo.IsEnabled = true;

                Invoice.Items.Clear(); // Will remove the current invoice that is being viewed if any
                lblCost.Content = "Cost:"; // Reset cost label
                lblInvoiceNum.Content = "Invoice Number: TBD"; // Reset invoice number label
                dpInvoiceDatePicker.SelectedDate = null;
                lblTotalCost.Content = "Total Cost: $0.00"; // Reset total cost label




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
                lblMessage.Content = "";    //reset message label
                lblMessage.Background = System.Windows.Media.Brushes.Transparent;   //reset message label background color
                btnSaveInvoice.IsEnabled = true; // Enable save button
                gbInvoiceInfo.IsEnabled = true; // Allow user to add items
                menuBar.IsEnabled = false; // Disable menu bar
                btnEditInvoice.IsEnabled = false; // Disable edit button
                btnCreateInvoice.IsEnabled = false; // Disable create invoice button
                dpInvoiceDatePicker.IsEnabled = false; //Disable date picker. User should not be able to change the date.
                btnCancel.IsEnabled = true; // Enable cancel button
                

                bEditingMode = true; // Put main window into editing mode

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
                gbInvoiceInfo.IsEnabled = false;  // Lock down window so no more changes can be made

                if(bEditingMode == true) // Check if in editing mode
                {
                    bEditingMode = false; //Take main window out of editing mode. 

                    Invoice.sTotalCost = fTotalCost.ToString();
                    Invoice.sInvoiceDate = dpInvoiceDatePicker.SelectedDate.ToString();

                    clsMainLogic.EditInvoice(Invoice); // Save changes


                }
                else if (bCreateInvoiceMode == true) //check if in creation mode
                {
                    bCreateInvoiceMode = false; //Take main window out of creation mode.

                    if (dpInvoiceDatePicker.SelectedDate == null) {
                        lblMessage.Content = "Must have date selected";
                    }
                    else
                    {
                        Invoice.sTotalCost = fTotalCost.ToString();
                        Invoice.sInvoiceDate = dpInvoiceDatePicker.SelectedDate.ToString(); 

                        clsMainLogic.SaveInvoice(Invoice); // Save info to database

                        Invoice.sInvoiceNum = clsMainLogic.getInvoiceNum();//get the invoice number from the database
                        lblInvoiceNum.Content = "Invoice Number: " + Invoice.sInvoiceNum; //Display the invoice number

                    }
                }

                lblMessage.Content = "Invoice Saved";
                lblMessage.Background = System.Windows.Media.Brushes.Green; // Change background color to green
                btnSaveInvoice.IsEnabled = false; // Disable save button
                menuBar.IsEnabled = true;
                btnEditInvoice.IsEnabled = true;
                btnCreateInvoice.IsEnabled = true; // Enable create invoice button
                gbInvoiceInfo.IsEnabled = false; // Disable group box controls
                dpInvoiceDatePicker.IsEnabled = true; //Disable date picker. User should not be able to change the date.
                btnCancel.IsEnabled = false; //disable cancel button




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
                if (Invoice.Items.Contains(SelectedItem))
                {
                    Invoice.Items.Remove(SelectedItem);
                    Invoice.Items.Remove(SelectedItem);
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
                //if (!Invoice.Items.Contains(SelectedItem)) // Avoid duplicates
                if (!Invoice.Items.Any(item => item.sItemCode == SelectedItem.sItemCode)) // Avoid duplicates
                {
                    Invoice.Items.Add(SelectedItem);
                    fTotalCost += float.Parse(SelectedItem.sItemCost);
                    lblTotalCost.Content = "Total Cost: $" + fTotalCost.ToString();

                }
            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(bCreateInvoiceMode == true) // Check if in creation mode
                {
                    Invoice.Items.Clear(); //clear out exisiting items
                    fTotalCost = 0; //reset total cost
                }
                else if (bEditingMode == true) // Check if in editing mode
                {
                    LoadSelectedInvoice(); // Load the selected invoice

                }
                gbInvoiceInfo.IsEnabled = false; // Disable group box controls
                btnSaveInvoice.IsEnabled = false; // Disable save button
                btnCancel.IsEnabled = false; // Disable cancel button
                menuBar.IsEnabled = true; // Enable menu bar
                btnCreateInvoice.IsEnabled = true; // Enable create invoice button


                bCreateInvoiceMode = false; //Take main window out of creation mode.
                bEditingMode = false; //Take main window out of editing mode.

            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }
        }


        private void LoadSelectedInvoice()
        {

            try
            {
                // Check if an invoice was selected
                if (sSelectedInvoiceNum != null)
                {
                    btnEditInvoice.IsEnabled = true; // Enable edit button

                    Invoice.Items.Clear(); //clear out exisiting items

                    GroupProject.Common.clsInvoice SelectedInvoice = new GroupProject.Common.clsInvoice();
                    // Get the invoice from the database
                    SelectedInvoice = clsMainLogic.GetInvoice(sSelectedInvoiceNum);


                    foreach (var item in SelectedInvoice.Items)
                    {
                        Invoice.Items.Add(item);    //Add items from selected invoice to the items list
                    }

                    fTotalCost = float.Parse(SelectedInvoice.sTotalCost); // Set the total cost to the selected invoices total cost
                    Invoice.sInvoiceNum = SelectedInvoice.sInvoiceNum; // Set the invoice number to the selected invoices invoice number
                                                                       // Update other UI elements 
                    lblInvoiceNum.Content = "Invoice Number: " + SelectedInvoice.sInvoiceNum;
                    lblTotalCost.Content = "Total Cost: $" + SelectedInvoice.sTotalCost;

                    if (DateTime.TryParse(SelectedInvoice.sInvoiceDate, out DateTime parsedDate))
                    {
                        dpInvoiceDatePicker.SelectedDate = parsedDate;
                    }
                    else
                    {
                        // Handle invalid date format
                        MessageBox.Show("The invoice date is not in a valid format.");
                        dpInvoiceDatePicker.SelectedDate = null;
                    }
                    //dpInvoiceDatePicker.SelectedDate = DateTime.Parse(Invoice.sInvoiceDate);
            }

            }
            catch (Exception ex)
            { clsMainLogic.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message); }


        }
    }
}


