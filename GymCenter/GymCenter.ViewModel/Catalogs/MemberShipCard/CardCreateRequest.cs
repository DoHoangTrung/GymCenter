using GymCenter.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.ViewModel.Catalogs.MemberShipCard
{
    public class CardCreateRequest
    {
        public Guid? UserId { get; set; }
        public MemberShipCardStatus Status { get; set; }
    }
}
