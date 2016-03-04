using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;
using SyncLayer.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq.Expressions;
using System.Reflection;
namespace SyncLayer.SyncTable
{
    public class MedicineFormSyncTable
    {
        private IMobileServiceSyncTable<MedicineForm> table = null;
        public MedicineFormSyncTable(Sync sync)
        {
            table = sync.GetTable<MedicineForm>();
        }
        public async Task InsertAsync(MedicineForm obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(MedicineForm obj)
        {
            await table.UpdateAsync(obj);
        }
        public async Task<List<MedicineForm>> ReadAsync()
        {
            List<MedicineForm> list = await table.ToListAsync();
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
