using SyncLayer;
using SyncLayer.DataModel;
using SyncLayer.SyncTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDA
    {
        private OrderHeaderSyncTable orderHeaderSyncTable;
        private TransactionDetailsSyncTable transactionDetailsSyncTable;
        public async static Task<OrderDA> Create()
        {
            OrderDA orderheaderDA = new OrderDA();
            Sync sync = await Sync.Create();
            orderheaderDA.orderHeaderSyncTable = new OrderHeaderSyncTable(sync);
            orderheaderDA.transactionDetailsSyncTable = new TransactionDetailsSyncTable(sync);
            return orderheaderDA;
        }
        public async Task<List<OrderHeader>> GetOrders(bool isDelivery)
        {
            List<OrderHeader> orderList = await orderHeaderSyncTable.GetOrders(Convert.ToInt32(isDelivery));
            return orderList;
        }

    }
}
