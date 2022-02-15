using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class ReceiptDetail
    {
        
        public int Id { get; set; }
        public int ReceiptId { set; get; }
        public int ServiceId { set; get; }
        public decimal Price { set; get; }
        public decimal Discount { set; get; }
        public decimal TotalPrice { set; get; }

        public Receipt Receipt { get; set; }
        public Service GymService { get; set; }

        
    }
}
