using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.ViewModel.Catalogs.Receipt
{
    public class ReceiptDetailViewModel
    {
        public int ServiceId { set; get; }
        public decimal Price { set; get; }
        public decimal Discount { set; get; }
        public decimal TotalPrice { set; get; }
    }
}
