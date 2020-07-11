using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUM.Services.Material.Common.Infrastructure
{
    public class Setting
    {
        public Database Database { get; set; }
        public string BaseUrl { get; set; }
    }

    public class Database
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
