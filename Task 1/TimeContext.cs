using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task_1
{
    class TimeContext : DbContext
    {
        public TimeContext()
           : base("DbConnection")
        { }

        public DbSet<Time> Times { get; set; }
    }
}
