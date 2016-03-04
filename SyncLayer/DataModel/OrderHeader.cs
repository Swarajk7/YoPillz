using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.DataModel
{
    public class OrderHeader
    {
        public string id { get; set; }
        public string StoreId { get; set; }
        public string OrderId { get; set; }
        public string TransactionType { get; set; }
        public string TaxInvoiceNumber { get; set; }
        public string CustomerId { get; set; }
        public float ShippingCharges { get; set; }
        public float  OrderAmount { get; set; }
        public float CommisionAmount { get; set; }
        public string OrderType { get; set; }
        public int OrderPriority { get; set; }
        public int IsDelivery { get; set; }
        public string DoctorId { get; set; }
        public float TotalRecipientAmount { get; set; }
        public DateTime FullfillmentDate { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
