using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class CheckInHistory
    {
        public int Id { get; set; }
        public int ServiceInCardId { get; set; }
        public DateTime Date { get; set; }

        public ServiceInCard ServiceInCard { get; set; }
    }
}
