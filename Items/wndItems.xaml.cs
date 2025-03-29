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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        public wndItems()
        {
            InitializeComponent();
        }

        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            // add item clicked enables text box fields
        }

        private void btn_EditItem_Click(object sender, RoutedEventArgs e)
        {
            // edit item click puts selected item into txt box fields
        }

        private void btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            // delete item checks if in an invoice, if not delete, else give user feedback
        }

        private void btn_SaveItem_Click(object sender, RoutedEventArgs e)
        {
            // only enabled when add item is clicked or edit item is clicked
        }

        private void btn_BackToHome_Click(object sender, RoutedEventArgs e)
        {
            //show the main window
            GroupProject.Main.wndMain mainWindow = new GroupProject.Main.wndMain();
            mainWindow.Show();

            // Close the current Items window
            this.Close();
        }
    }
}
