using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.DataModel
{
    public class AilmentSubCategory
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "ailmentsubcategoryId")]
        public int AilmentSubCategoryId { get; set; }
        [JsonProperty(PropertyName = "ailmentsubcategoryname")]
        public string AilmentSubCategoryName { get; set; }
        [JsonProperty(PropertyName = "ailmentcategoryId")]
        public float AilmentCategoryId { get; set; }
        [JsonProperty(PropertyName = "storeid")]
        public string StoreId { get; set; }

        public override string ToString()
        {
            return "AilmentSubCategory";
        }
    }
}
