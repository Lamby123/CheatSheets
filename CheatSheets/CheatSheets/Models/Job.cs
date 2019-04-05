using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
