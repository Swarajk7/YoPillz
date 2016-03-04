using SyncLayer.DataModel;
using SyncLayer.SyncTable;
using SyncLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IMedicineDA
    {
        Task<List<Medicine>> ReadMedicineWithMedicineName(string medicineName);
    }
    public class MedicineDA : IMedicineDA
    {
        private MedicineSyncTable medicineSyncTable;
        public async static Task<MedicineDA> Create()
        {
            MedicineDA medDA = new MedicineDA();
            Sync sync = await Sync.Create();
            medDA.medicineSyncTable = new MedicineSyncTable(sync);
            return medDA;
        }
        public async Task<List<Medicine>> ReadMedicineWithMedicineName(string medicineName)
        {
            List<Medicine> medicineList = await medicineSyncTable.FetchMedicinesWithName(medicineName);
            if (medicineList.Count > 0)
            {
                return medicineList;
            }
            else
            {
                throw new Exception("No Medicine Found");
            }
        }
        public async Task<Medicine> ReadMedicineWithMedicineCode(string medicineCode)
        {
            List<Medicine> medicineList = await medicineSyncTable.FetchMedicinesWithCode(medicineCode);
            if (medicineList.Count == 1)
            {
                return medicineList[0];
            }
            else if (medicineList.Count == 0)
            {
                throw new Exception("No Medicine Found");
            }
            return null;
        }
    }
}
