using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DAL
{
    public class SqlliteManager
    {
        private static SQLiteConnection DbConnection
        {
            get
            {
                return new SQLiteConnection(
                    new SQLitePlatformWinRT(),
                    Path.Combine(ApplicationData.Current.LocalFolder.Path, "Storage.sqlite"));
            }
        }
        public static List<T> ExecuteQuery<T>(string query) where T : class
        {
            List<T> list = null;
            using (var db = DbConnection)
            {
                list = db.Query<T>(query).ToList();
            }
            return list;
        }
    }
}
