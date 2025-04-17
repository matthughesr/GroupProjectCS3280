using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using GroupProject.Common;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// Indicates whether the items table was updated.
        /// </summary>
        public bool ItemsTableUpdated { get; private set; } = false;

        /// <summary>
        /// Initializes window
        /// </summary>
        public wndItems()
        {
            InitializeComponent();
            LoadItems();
        }

        /// <summary>
        /// Loads all items into the DataGrid.
        /// </summary>
        private void LoadItems()
        {
            try
            {
                // Retrieve all items using clsItemsLogic
                var items = clsItemsLogic.RetrieveAllItems();
                dataGrid_DisplayItems.ItemsSource = items;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void txtLetterInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Get the TextBox that triggered the event
                TextBox textBox = sender as TextBox;

                if (textBox != null)
                {
                    // Check if the TextBox is for Item Description
                    if (textBox.Name == "txtBox_ItemDescr")
                    {
                        // Allow only up to 35 characters
                        if (textBox.Text.Length >= 35 && !(e.Key == Key.Back || e.Key == Key.Delete))
                        {
                            e.Handled = true;
                        }
                    }
                    // Check if the TextBox is for Item Code
                    else if (textBox.Name == "txtBox_ItemCode")
                    {
                        // Allow only letters and up to 10 characters
                        if (!(e.Key >= Key.A && e.Key <= Key.Z) && !(e.Key == Key.Back || e.Key == Key.Delete))
                        {
                            e.Handled = true;
                        }
                        else if (textBox.Text.Length >= 10 && !(e.Key == Key.Back || e.Key == Key.Delete))
                        {
                            e.Handled = true;
                        }
                    }
                    // Check if the TextBox is for Item Cost
                    else if (textBox.Name == "txtBox_ItemPrice")
                    {
                        // Allow only numbers
                        if (!(e.Key >= Key.D0 && e.Key <= Key.D9) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) &&
                            !(e.Key == Key.Back || e.Key == Key.Delete))
                        {
                            e.Handled = true;
                        } else if (textBox.Text.Length >= 10 && !(e.Key == Key.Back || e.Key == Key.Delete))
                        {
                            e.Handled = true;
                           
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the Add Item button click event.
        /// Enables text box fields for adding a new item and clears their content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            // Enable text box fields for adding a new item
            txtBox_ItemCode.IsEnabled = true;
            txtBox_ItemDescr.IsEnabled = true;
            txtBox_ItemPrice.IsEnabled = true;
            btn_SaveItem.IsEnabled = true;
            btn_AddItem.IsEnabled = false; // Disable Add button while adding a new item
            btn_EditItem.IsEnabled = false; // Disable Edit button while adding a new item
            btn_DeleteItem.IsEnabled = false; // Disable Delete button while adding a new item

            // Clear the text boxes to allow for new input
            txtBox_ItemCode.Text = string.Empty;
            txtBox_ItemDescr.Text = string.Empty;
            txtBox_ItemPrice.Text = string.Empty;
        }

        /// <summary>
        /// Handles the Edit Item button click event.
        /// Populates the text boxes with the selected item's details for editing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btn_EditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected item from the DataGrid
                if (dataGrid_DisplayItems.SelectedItem is clsItem selectedItem)
                {
                    // Populate the text boxes with the selected item's details
                    txtBox_ItemCode.Text = selectedItem.sItemCode;
                    txtBox_ItemDescr.Text = selectedItem.sItemDescription;
                    txtBox_ItemPrice.Text = selectedItem.sItemCost;

                    // Enable the text boxes for editing, except for the ItemCode
                    txtBox_ItemCode.IsEnabled = false; // ItemCode should not be editable
                    txtBox_ItemDescr.IsEnabled = true;
                    txtBox_ItemPrice.IsEnabled = true;
                    btn_SaveItem.IsEnabled = true;
                    btn_AddItem.IsEnabled = false; // Disable Add button while editing
                    btn_EditItem.IsEnabled = false; // Disable Edit button while editing
                    btn_DeleteItem.IsEnabled = false; // Disable Delete button while editing
                }
                else
                {
                    MessageBox.Show("Please select a valid item to edit.");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the Delete Item button click event.
        /// Checks if the item is associated with invoices before allowing deletion.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if there is an item selected
                if (dataGrid_DisplayItems.SelectedItem is clsItem selectedItem)
                {
                    // Get the list of associated invoices
                    var invoiceNumbers = clsItemsLogic.GetItemInvoiceNumbers(selectedItem.sItemCode);

                    if (invoiceNumbers.Count > 0)
                    {
                        // If in an invoice, show a message with the invoice numbers
                        string invoices = string.Join(", ", invoiceNumbers);
                        MessageBox.Show($"The item '{selectedItem.sItemDescription}' is associated with the following invoices: {invoices}. It cannot be deleted.",
                                        "Item In Use", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        // Confirm deletion with the user
                        var result = MessageBox.Show($"Are you sure you want to delete the item '{selectedItem.sItemDescription}'?",
                                                     "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (result == MessageBoxResult.Yes)
                        {
                            clsItemsLogic.DeleteItem(selectedItem);
                            MessageBox.Show("Item deleted successfully.");
                            LoadItems(); // Reload the items to reflect changes

                            // Mark the items table as updated
                            ItemsTableUpdated = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid item to delete.");
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the Save Item button click event.
        /// Saves a new item or updates an existing item based on the current state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btn_SaveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtBox_ItemCode.Text) ||
                    string.IsNullOrWhiteSpace(txtBox_ItemDescr.Text) ||
                    string.IsNullOrWhiteSpace(txtBox_ItemPrice.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                // Create a new clsItem object with the data from the text boxes
                clsItem newItem = new clsItem
                {
                    sItemCode = txtBox_ItemCode.Text,
                    sItemDescription = txtBox_ItemDescr.Text,
                    sItemCost = txtBox_ItemPrice.Text
                };

                // Check if we are adding a new item or editing an existing one
                if (txtBox_ItemCode.IsEnabled) // Adding a new item
                {
                    clsItemsLogic.AddItem(newItem);
                    //MessageBox.Show("Item added successfully.");
                }
                else // Editing an existing item
                {
                    if (dataGrid_DisplayItems.SelectedItem is clsItem oldItem)
                    {
                        clsItemsLogic.EditItem(oldItem, newItem);
                        MessageBox.Show("Item updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error: No item selected for editing.");
                    }
                }

                // Reload the items to reflect changes
                LoadItems();

                // Mark the items table as updated
                ItemsTableUpdated = true;

                // Disable text boxes after saving
                txtBox_ItemCode.IsEnabled = false;
                txtBox_ItemDescr.IsEnabled = false;
                txtBox_ItemPrice.IsEnabled = false;
                btn_DeleteItem.IsEnabled = true; // Enable Delete button
                btn_AddItem.IsEnabled = true; // Enable Add button
                btn_EditItem.IsEnabled = true; // Enable Edit button
                btn_SaveItem.IsEnabled = false; // Disable Save button
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the Back to Home button click event.
        /// Closes the current window and ensures the main window knows if the items table was updated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btn_BackToHome_Click(object sender, RoutedEventArgs e)
        {
            // Close the current Items window
            this.Close();
        }

        /// <summary>
        /// Handles errors by displaying a message box and logging the error.
        /// </summary>
        /// <param name="sClass">The class where the error occurred.</param>
        /// <param name="sMethod">The method where the error occurred.</param>
        /// <param name="sMessage">The error message.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Cancel Item button click event.
        /// Clears the text boxes and resets the form to its original state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btn_CancelItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear the text boxes
                txtBox_ItemCode.Text = string.Empty;
                txtBox_ItemDescr.Text = string.Empty;
                txtBox_ItemPrice.Text = string.Empty;

                // Disable the text boxes and Save button
                txtBox_ItemCode.IsEnabled = false;
                txtBox_ItemDescr.IsEnabled = false;
                txtBox_ItemPrice.IsEnabled = false;
                btn_SaveItem.IsEnabled = false;
                btn_DeleteItem.IsEnabled = true; // Enable Delete button
                btn_AddItem.IsEnabled = true; // Enable Add button
                btn_EditItem.IsEnabled = true; // Enable Edit button

                // deselect any selected item in the DataGrid
                dataGrid_DisplayItems.SelectedItem = null;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
