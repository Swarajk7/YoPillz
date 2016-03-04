using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.DataModel
{
    public class TransactionDetails
    {
        public string id { get; set; }
        public string StoreId { get; set; }
        public string OrderId { get; set; }
        public string TransactionId { get; set; }
        public string MedicineCode { get; set; }
        public int Quantity { get; set; }
        public float MedicineCost { get; set; }
        public float DiscountAmount { get; set; }
        public float Tax { get; set; }
        public float TotalAmount { get; set; }
        public int IsReturned { get; set; }
        public int IsCanceled { get; set; }
    }
}
