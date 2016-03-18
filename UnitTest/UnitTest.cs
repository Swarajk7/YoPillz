using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SyncLayer;
using SyncLayer.DataModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using DAL.Quries;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MedicineQueryTest()
        {
            Assert.AreEqual("Select MedicineName,MedicineCode from Medicine Where MedicineName Like 'calp%'", MedicineQuery.GetQuery(MedicineQuery.QueryType.StartsWithMedicineName, "calp"));
            Assert.AreEqual("Select * from Medicine Where MedicineCode = 'abcd'", MedicineQuery.GetQuery(MedicineQuery.QueryType.WithMedicineCode, "abcd"));
            try
            {
                Assert.AreEqual("", MedicineQuery.GetQuery(MedicineQuery.QueryType.StartsWithMedicineName, null));
                Assert.Fail();
            }
            catch { }
        }
    }
}
