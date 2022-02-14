﻿using GymCenter.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class Register
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public DateTime Date { get; set; }
        public RegisterStatus Status { get; set; }
        public decimal TotalCash { get; set; }

        public AppUser User { get; set; }

        public List<RegisterDetail> RegisterDetails { get; set; }
    }
}
