using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using YOPILLZ.BusinessObjects;

namespace YOPILLZ.Model
{
    public class SearchAndSelectViewModel
    {
        private ObservableCollection<SearchMedicineResult> medicines;
        private SearchMedicineResult selectedMedicine;

        public SearchAndSelectViewModel()
        {
           
        }

        public ObservableCollection<SearchMedicineResult> SearchMedicineResults
        {
            get
            {
                return this.medicines;
            }
        }

        private void UpdateProducts(string filter)
        {
            //call search with this filter and update this.medicines

            var myProducts = new ObservableCollection<SearchMedicineResult>();

            myProducts.Add(new SearchMedicineResult() { MedicineName = "calpol 125", MedicineCode = "Calpol-125MG" });
            myProducts.Add(new SearchMedicineResult() { MedicineName = "Crocin 100", MedicineCode = "Crocin-100MG" });
            myProducts.Add(new SearchMedicineResult() { MedicineName = "Crocin 250", MedicineCode = "Crocin-250MG" });
            myProducts.Add(new SearchMedicineResult() { MedicineName = "DOLO 250", MedicineCode = "DOLO-250MG" });
            myProducts.Add(new SearchMedicineResult() { MedicineName = "DOLO 500", MedicineCode = "DOLO-500MG" });
          

            this.medicines = myProducts;
        }

        public SearchMedicineResult SelectedMedicine
        {
            get
            {
                return this.selectedMedicine;
            }
            set
            {
                if (this.selectedMedicine != value)
                {
                    this.selectedMedicine = value;
                }
            }
        }

        private string filter;

        public string Filter
        {
            get
            {
                return this.filter.ToUpperInvariant();
            }
            set
            {
                if (this.filter != value)
                {
                    this.filter = value;
                    if (value.Length > 3)
                    {
                        //call search and assign that result to this.medicines
                    }
                    else
                    {
                        //if length is less than 3 don't show anything
                        this.medicines.Clear();
                    }
                }
            }
        }

        private bool ContainsFilter(object item)
        {
            var medicine = item as SearchMedicineResult;
            if (medicine == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(this.Filter))
            {
                return true;
            }

            if (medicine.MedicineName.ToUpperInvariant().Contains(this.Filter))
            {
                return true;
            }

            return false;
        }
    }
}
