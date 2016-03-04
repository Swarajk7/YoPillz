using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.DataModel
{
    public class AilmentCategory
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "ailmentcategoryId")]
        public int AilmentCategoryId { get; set; }
        [JsonProperty(PropertyName = "ailmentcategoryname")]
        public string AilmentCategoryName { get; set; }
        [JsonProperty(PropertyName = "storeid")]
        public string StoreId { get; set; }
    }
}
