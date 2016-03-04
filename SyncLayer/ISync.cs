using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer
{
    public interface ISync
    {
        Task<ISync> Create();
        Task PushAsync();
        Task PullAsync<T>(Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<T> table);
    }
}
