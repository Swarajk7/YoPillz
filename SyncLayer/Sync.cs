using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using SyncLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace SyncLayer
{
    public class Sync
    {
        private static MobileServiceClient MSClient = null;
        public static Sync MSobj;
        public static string MobileAppURL = "http://yopillz2.azurewebsites.net";
        private static bool HasStoreInitialized = false;
        private Sync()
        {
            MSClient = new MobileServiceClient(Sync.MobileAppURL);
        }
        public async static Task<Sync> Create()
        {
            if (MSobj == null)
            {
                MSobj = new Sync();
                //await InitLocalStoreAsync();
            }
            await InitLocalStoreAsync();
            return MSobj;
        }
        public IMobileServiceSyncTable<T> GetTable<T>()
        {
            return MSClient.GetSyncTable<T>();
        }
        public async static Task InitLocalStoreAsync()
        {
            if (!MSClient.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("MyDataBase.sqlite");
                store.DefineTable<AilmentCategory>();
                store.DefineTable<AilmentSubCategory>();
                store.DefineTable<MedicineForm>();
                store.DefineTable<Medicine>();
                store.DefineTable<OrderHeader>();
                await MSClient.SyncContext.InitializeAsync(store);
                HasStoreInitialized = true;
            }
            //await SyncAsync();
        }
        public bool IsStoreInitialized()
        {
            return HasStoreInitialized;
        }
        public async Task PushAsync()
        {
            try
            {
                await MSClient.SyncContext.PushAsync();
            }
            catch(MobileServicePushFailedException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
