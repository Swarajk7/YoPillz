using DAL;
using SyncLayer;
using SyncLayer.DataModel;
using SyncLayer.SyncTable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YOPILLZ.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        List<Medicine> medicineList = null;
        MedicineDA medicineDA = null;
        public Search()
        {
            this.InitializeComponent();
            List<OrderEntity> orderlist = new List<OrderEntity>();
            orderlist.Add(new OrderEntity { OrderId = "12346758", CustomerName = "Swaraj" });
            orderlist.Add(new OrderEntity { OrderId = "89765410", CustomerName = "Sumit" });
            OrderList.ItemsSource = orderlist;
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //medicineDA = await MedicineDA.Create();
            //Sync sync = await Sync.Create();
            //OrderHeaderSyncTable ohstable = new OrderHeaderSyncTable(sync);
            //await ohstable.PullWithStoreIdAsync("1");
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Page destinationPage = e.Content as Page;
            if(destinationPage!= null)
            {
                if(destinationPage.ToString() == "DrugDetailPage")
                {
                    destinationPage.Tag = tb_medicine.Tag;
                }
            }
        }
        private void tb_medicine_LostFocus(object sender, RoutedEventArgs e)
        {
            listbox.Visibility = Visibility.Collapsed;
            MyGrid.Visibility = Visibility.Visible;
            medicineList = null;
            //listbox.ItemsSource = medicineList;
            //Medicine = null;
        }

        private void tb_medicine_GotFocus(object sender, RoutedEventArgs e)
        {
            listbox.Visibility = Visibility.Visible;
            MyGrid.Visibility = Visibility.Collapsed;
        }

        private void AddtoOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            OrderList.Visibility = Visibility.Visible;
        }

        private void OrderListItemSelected(object sender, SelectionChangedEventArgs e)
        {
            OrderEntity a = e.AddedItems[0] as OrderEntity;
            OrderEntity b = (sender as ListBox).SelectedItem as OrderEntity;
            OrderList.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(CreateOrder), tb_medicine.Tag);
        }

        private void drugDetailButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DrugDetail), tb_medicine.Tag);
        }

        private async void tb_medicine_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tb_medicine.Text.Length > 2)
            {
                //medicineList = await medicineDA.ReadMedicineWithMedicineName(tb_medicine.Text);
                //listbox.ItemsSource = medicineList;
            }
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medicine med = (sender as ListView).SelectedItem as Medicine;
            if (med != null)
            {
                tb_medicine.Text = med.MedicineName;
                tb_medicine.Tag = med.MedicineCode;
            }
        }
    }
    public class OrderEntity
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public override string ToString()
        {
            return OrderId + "," + CustomerName;
        }
    }
}
