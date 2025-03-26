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
        /// Function that checks the search type slider and displays the correct group box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderClick(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                double sliderValue = e.NewValue;

                if (sliderValue == 1)
                {
                    // Hide invoice group box
                    invoiceGroupBox.Visibility = Visibility.Hidden;
                    invoiceGroupBox.IsEnabled = false;

                    // Show Item code group box
                    itemCodeGroupBox.Visibility = Visibility.Visible;
                    itemCodeGroupBox.IsEnabled = true;

                    searchTypeLabel.Content = "Via Item Code";
                }
                else
                {
                    // Show invoice group box
                    invoiceGroupBox.Visibility = Visibility.Visible;
                    invoiceGroupBox.IsEnabled = true;

                    // Hide Item code Group box
                    itemCodeGroupBox.Visibility = Visibility.Hidden;
                    itemCodeGroupBox.IsEnabled = false;

                    searchTypeLabel.Content = "Via Invoice Number";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
