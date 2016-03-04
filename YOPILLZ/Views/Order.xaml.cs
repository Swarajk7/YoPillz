﻿using System;
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
using SyncLayer.DataModel;
using DAL;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YOPILLZ.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Order : Page
    {
        public Order()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            OrderDA orderHeaderDA = await OrderDA.Create();
            List<OrderHeader> orderList = await orderHeaderDA.GetOrders(true);
            List<OrderHeader> orderList2 = await orderHeaderDA.GetOrders(false);
            DeliveryData.Text = orderList.Count.ToString();
            InStoreData.Text = orderList2.Count.ToString();
        }
    }
}