using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SyncLayer;
using SyncLayer.DataModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task PullTest()
        {
            Sync sync = await Sync.Create();
            SyncTable<AilmentCategory> syncTable = new SyncTable<AilmentCategory>(sync);
            //await syncTable.InsertAsync(new AilmentCategory { AilmentCategoryId = 1, AilmentCategoryName = "abc", StoreId = "1" });
            await syncTable.PullAsync(syncTable.ToString(),syncTable.GetQuery());
            List<AilmentCategory> readList = await syncTable.ReadAsync();
            Assert.AreNotEqual(0, readList.Count);
            foreach(AilmentCategory ac in readList)
            {
                Assert.AreEqual("1", ac.StoreId);
            }
        }
    }
}
