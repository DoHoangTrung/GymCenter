using GymCenter.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.ViewModel.Catalogs.Receipt
{
    public class ReceiptCreateRequest
    {
        public Guid? UserId { get; set; }
        public DateTime Date { get; set; }
        public string CashierName { get; set; } 
        public decimal TotalCash { get; set; }
        public List<ReceiptDetailViewModel> Details { get; set; }
    }
}
