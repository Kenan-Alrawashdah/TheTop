using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheTop.ViewModels
{
    public class HomeAdminVM
    {
        public SearchVM Search { get; set; }

        public ICollection<OrderVM> Orders { get; set; }

        public int CountReviews { get; set; }

        public int CountAdvertisements { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal Profitable { get; set; }
    }
}
