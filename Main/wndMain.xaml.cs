using GroupProject.Items;
using GroupProject.Search;
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

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();
        }

        private void openSearchWindow(object sender , RoutedEventArgs e)
        {
            wndSearch searchWindow = new wndSearch();

            this.Hide();
            searchWindow.ShowDialog();
            this.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndItems itemsWindow = new wndItems();

            this.Hide();
            itemsWindow.ShowDialog();
            this.Show();
        }




        //Invoice ID will be extracted from search window by a public property 
        //

        //
    }
}
