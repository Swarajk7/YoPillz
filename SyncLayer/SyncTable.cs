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

namespace SyncLayer
{
    public class SyncTable<T>
    {
        private IMobileServiceSyncTable<T> table = null;
        public SyncTable(Sync sync)
        {
            table = sync.GetTable<T>();
        }
        public async Task InsertAsync(T obj)
        {
            await table.InsertAsync(obj);
        }
        public async Task UpdateAsync(T obj)
        {
            await table.UpdateAsync(obj);
        }
        public IMobileServiceTableQuery<T> GetQuery(string storeid)
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            var property = typeof(T).GetProperty("StoreId",BindingFlags.Public|BindingFlags.Instance);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            Expression equalExpression = Expression.Equal(propertyAccess, Expression.Constant("1"));
            var whereExpression = Expression.Lambda<Func<T, bool>>(equalExpression, parameter);
            var qu = table.Where(whereExpression);
            return qu;
        }
        public IMobileServiceTableQuery<T> GetQuery()
        {
            return table.CreateQuery();
        }
        public async Task PullAsync(string queryid)
        {
            try
            {
                await table.PullAsync(table.ToString(), table.CreateQuery());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<T>> ReadAsync()
        {
            List<T> list = await table.ToListAsync();
            return list;
        }
        public async Task PullAsync(string queryid,IMobileServiceTableQuery<T> query)
        {
            await table.PullAsync(queryid, query);
        }
        public override string ToString()
        {
            return typeof(T).Name;
        }
    }
}
