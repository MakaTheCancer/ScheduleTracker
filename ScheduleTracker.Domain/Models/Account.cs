using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTracker.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public string UserIdentity { get; set; }
        public IEnumerable<Scheduling> Schedulings { get; set; }
    }
}
