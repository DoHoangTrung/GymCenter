using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.ViewModel.Catalogs.Service
{
    public class ServiceUpdateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int NumberDaysUse { get; set; }
        public int? NumberCheckInUse { get; set; }
        public TimeSpan? TimeOfDayStart { get; set; }
        public TimeSpan? TimeOfDayEnd { get; set; }
        public int? MaxMemberCount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
