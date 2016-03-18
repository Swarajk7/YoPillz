using SyncLayer.DataModel;
using SyncLayer.SyncTable;
using SyncLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOPILLZ.BusinessObjects;
using DAL.Quries;

namespace DAL
{
    
    public class MedicineDA 
    {
        public List<SearchMedicineResult> SearchMedicine(string startsWith)
        {
            string query = MedicineQuery.GetQuery(MedicineQuery.QueryType.StartsWithMedicineName, startsWith);
            return SqlliteManager.ExecuteQuery<SearchMedicineResult>(query);
        }
    }
}
