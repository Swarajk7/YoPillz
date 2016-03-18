using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Quries
{
    public class MedicineQuery
    {
        public enum QueryType
        {
            StartsWithMedicineName,
            WithMedicineCode
        }

        public static string GetQuery(QueryType queryType,string param1)
        {
            switch(queryType)
            {
                case QueryType.StartsWithMedicineName:
                    if (param1 != null)
                    {
                        return String.Format("Select MedicineName,MedicineCode from Medicine Where MedicineName Like '{0}%'", param1);
                    }
                    break;
                case QueryType.WithMedicineCode:
                    if(param1!= null)
                    {
                        return String.Format("Select * from Medicine Where MedicineCode = '{0}'", param1);
                    }
                    break;
            }
            throw new Exception("Invalid Call");
        }
    }
}
