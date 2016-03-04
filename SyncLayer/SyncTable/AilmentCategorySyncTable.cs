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
    public class AilmentCategorySyncTable
    {
        private IMobileServiceSyncTable<AilmentCategory> table = null;
        public AilmentCategorySyncTable(Sync sync)
        {
            table = sync.GetTable<AilmentCategory>();
        }
        public async Task InsertAsync(AilmentCategory obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(AilmentCategory obj)
        {
            await table.UpdateAsync(obj);
        }
        public async Task PullAsync()
        {
            try
            {
                await table.PullAsync("AC", table.CreateQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<AilmentCategory>> ReadAsync()
        {
            List<AilmentCategory> list = await table.Where(s => s.StoreId == "1").ToListAsync();
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
