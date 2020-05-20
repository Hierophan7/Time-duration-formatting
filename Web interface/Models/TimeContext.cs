using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Web_interface
{
    class TimeContext : DbContext
    {
        public TimeContext() : base("DbConnection")
        {
            Database.SetInitializer(new TimeInitializer());
        }

        public DbSet<Time> Times { get; set; }
    }
}
