using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTracker.Domain.Models
{
    public class Scheduling : DomainObject
    {
        public Account Account { get; set; }
        public bool IsCreated { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
