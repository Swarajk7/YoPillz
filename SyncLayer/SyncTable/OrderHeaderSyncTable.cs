using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using SyncLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.SyncTable
{
    public class OrderHeaderSyncTable
    {
        private IMobileServiceSyncTable<OrderHeader> table = null;
        public OrderHeaderSyncTable(Sync sync)
        {
            table = sync.GetTable<OrderHeader>();
        }
        public async Task InsertAsync(OrderHeader obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(OrderHeader obj)
        {
            await table.UpdateAsync(obj);
        }

        public async Task<List<OrderHeader>> GetOrders(int isDelivery)
        {
            var selectorder = from order in table where order.IsDelivery == isDelivery 
                              //&& order.FullfillmentDate == null
                              select order;
            return await selectorder.ToListAsync();
        }

        public async Task<List<OrderHeader>> ReadAsync()
        {
            List<OrderHeader> list = await table.ToListAsync();
            return list;
        }
        public async Task PullWithStoreIdAsync(string storeid)
        {
            try
            {
                await table.PullAsync(this.GetType().Name, table.Where(store => store.StoreId == storeid));
            }
            catch
            {
                throw;
            }
        }
    }
}
