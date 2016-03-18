using SyncLayer;
using SyncLayer.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SyncLayer.SyncTable;
using YOPILLZ.Views;
using DAL;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YOPILLZ
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MedicineDA medicineDa = new MedicineDA();
            medicineDa.SearchMedicine("calp");
        }
        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myListBox.SelectedIndex == 1)
            {
                //if (order == null) order = new Orders();
                frame.Navigate(typeof(Order), null);
            }
            else if (myListBox.SelectedIndex == 2)
            {
                //if (search == null) search = new Search();
                frame.Navigate(typeof(Search), null);
            }
            else if (myListBox.SelectedIndex == 3)
            {
                frame.Navigate(typeof(Inventory), null);
            }
        }



        private void mySplitView_PaneClosed(SplitView sender, object args)
        {
            SearchText.Visibility = Visibility.Collapsed;
            OrderText.Visibility = Visibility.Collapsed;
            InventoryText.Visibility = Visibility.Collapsed;
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {

        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {

        }
        
        private void Manipulate_SplitView()
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            SearchText.Visibility = Visibility.Visible;
            OrderText.Visibility = Visibility.Visible;
            InventoryText.Visibility = Visibility.Visible;
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            Manipulate_SplitView();
        }
    }
}
