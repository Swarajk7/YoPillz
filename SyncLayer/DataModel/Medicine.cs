using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncLayer.DataModel
{
    public class Medicine
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName ="medicinecode")]
        public string MedicineCode { get; set; }
        [JsonProperty(PropertyName ="medicinename")]
        public string MedicineName { get; set; }
        [JsonProperty(PropertyName ="medicineformid")]
        public int MedicineFormId { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "manufacturercompany")]
        public string ManufacturerCompany { get; set; }
        [JsonProperty(PropertyName = "discountpercentage")]
        public float DiscountPercentage { get; set; }
        [JsonProperty(PropertyName = "schedule")]
        public string Schedule { get; set; }
        [JsonProperty(PropertyName = "onlysellableinbatch")]
        public int OnlySellableInBatch { get; set; }
        [JsonProperty(PropertyName = "ailmentsubcategoryid")]
        public int AilmentSubCategoryId { get; set; }
        [JsonProperty(PropertyName = "productsubcategoryid")]
        public int ProductSubCategoryId { get; set; }
        [JsonProperty(PropertyName = "medicinefieldid")]
        public int MedicineFieldId { get; set; }
        [JsonProperty(PropertyName = "genericname")]
        public string GenericName { get; set; }
        [JsonProperty(PropertyName = "dosage")]
        public string Dosage { get; set; }
        [JsonProperty(PropertyName = "composition")]
        public string Composition { get; set; }
        [JsonProperty(PropertyName = "vat")]
        public float VAT { get; set; }
        [JsonProperty(PropertyName = "barcode")]
        public string BarCode { get; set; }
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
        [JsonProperty(PropertyName = "marginpercentage")]
        public float MarginPercentage { get; set; }
        [JsonProperty(PropertyName = "storeid")]
        public string StoreId { get; set; }
    }
}
