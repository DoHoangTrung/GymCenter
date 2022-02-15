using GymCenter.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class MembershipCard
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public MemberShipCardStatus Status { get; set; }
        public AppUser User { get; set; }
        public List<ServiceInCard> ServiceInCards { get; set; }
    }
}
