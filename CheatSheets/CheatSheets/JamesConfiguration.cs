using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets
{
    public interface IJamesConfiguration
    {
        string JamesDbConnectionString { get; set; }
    }
    public class JamesConfiguration : IJamesConfiguration
    {
        public string JamesDbConnectionString { get; set; }
    }
}
