using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class AppUser : IdentityUser<Guid>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string ImagePath { get; set; }

        public List<MembershipCard> MembershipCards { get; set; }
        public List<Receipt> Receipts{ get; set; }
        public List<Register> Registers { get; set; }
    }
}
