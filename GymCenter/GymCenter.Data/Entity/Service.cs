using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int NumberDaysUse { get; set; }
        public int? CheckInUse { get; set; }
        public TimeSpan? TimeOfDayStart { get; set; }
        public TimeSpan? TimeOfDayEnd { get; set; }
        public int? MaxMemberCount { get; set; }
        public int? MemberCount { get; set; }
        public string Description{ get; set; }
        public int CategoryId { get; set; }

        
        public Category Category { get; set; }
        public List<RegisterDetail>  RegisterDetails { get; set; }
        public List<ReceiptDetail>  ReceiptDetails { get; set; }
        public List<ServiceInCard>  ServiceInCards { get; set; }
    }
}
