using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.DataModel
{
    public class MedicineForm
    {
        [JsonProperty(PropertyName = "id")]
        public string id
        {
            get; set;
        }
        [JsonProperty(PropertyName = "MedicineFormId")]
        public int MedicineFormId { get; set; }
        [JsonProperty(PropertyName = "MedicineFormName")]
        public string MedicineFormName { get; set; }
        [JsonProperty(PropertyName = "StoreId")]
        public string StoreId { get; set; }
    }
}
