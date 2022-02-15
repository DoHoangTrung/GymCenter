using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class ServiceInCard
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? CheckinCount { get; set; }
        public int? MaxCheckinCount { get; set; }

        public MembershipCard MembershipCard { get; set; }
        public Service GymService { get; set; }
        public List<CheckInHistory> CheckInHistories { get; set; }
    }
}
