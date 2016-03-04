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
    public class MedicineSyncTable
    {
        private IMobileServiceSyncTable<Medicine> table = null;
        public MedicineSyncTable(Sync sync)
        {
            table = sync.GetTable<Medicine>();
        }
        public async Task InsertAsync(Medicine obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(Medicine obj)
        {
            await table.UpdateAsync(obj);
        }
        public async Task<List<Medicine>> ReadAsync()
        {
            List<Medicine> list = await table.ToListAsync();
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
        public async Task<List<Medicine>> FetchMedicinesWithName(string medicineName)
        {
            //return await table.ToListAsync();
            return await table.Where(s => s.MedicineName.ToLower().StartsWith(medicineName.ToLower())).ToListAsync();
        }
        public async Task<List<Medicine>> FetchMedicinesWithCode(string medicineCode)
        {
            var selectmed = from med in table where med.MedicineCode == medicineCode select med;
            return await selectmed.ToListAsync();
        }
    }
}
