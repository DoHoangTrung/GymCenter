using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class RegisterDetail
    {
        public int Id { get; set; }
        public int ServiceId { set; get; }
        public int RegisterId { set; get; }
        public decimal Price { set; get; }
        public decimal Discount { set; get; }
        public decimal TotalPrice { set; get; }

        public Service GymService { get; set; }

        public Register Register { get; set; }
    }
}
