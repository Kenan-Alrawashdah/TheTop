using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheTop.ViewModels
{
    public class HomeCustomerVM
    {
        public ICollection<AdvertisementVM> Advertisements { get; set; }
        public int CountAdvertisements { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
