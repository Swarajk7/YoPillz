using Microsoft.WindowsAzure.MobileServices.Sync;
using SyncLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.SyncTable
{
    public class TransactionDetailsSyncTable
    {
        private IMobileServiceSyncTable<TransactionDetails> table = null;
        public TransactionDetailsSyncTable(Sync sync)
        {
            table = sync.GetTable<TransactionDetails>();
        }
        public async Task InsertAsync(TransactionDetails obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(TransactionDetails obj)
        {
            await table.UpdateAsync(obj);
        }
    }
}
