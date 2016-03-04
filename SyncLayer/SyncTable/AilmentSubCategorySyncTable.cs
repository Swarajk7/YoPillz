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
    public class AilmentSubCategorySyncTable
    {
        private IMobileServiceSyncTable<AilmentSubCategory> table = null;
        public AilmentSubCategorySyncTable(Sync sync)
        {
            table = sync.GetTable<AilmentSubCategory>();
        }
        public async Task InsertAsync(AilmentSubCategory obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(AilmentSubCategory obj)
        {
            await table.UpdateAsync(obj);
        }
        public async Task<List<AilmentSubCategory>> ReadAsync()
        {
            List<AilmentSubCategory> list = await table.ToListAsync();
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
