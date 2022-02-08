using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorgovyAutomat.Model
{
   public partial class DrinksRepositoryJson
    {
            public object[] VendingMachineDrinks { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string Image { get; set; }
            public float Cost { get; set; }
    }
}
