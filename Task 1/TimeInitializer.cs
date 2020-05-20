using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task_1
{
    class TimeInitializer : DropCreateDatabaseIfModelChanges<TimeContext>
    {
        protected override void Seed(TimeContext context)
        {
            IList<Time> Times = new List<Time>();
            Times.Add(new Time() { Output = "Test data: 1 year, 50 minutes and 12 seconds" });
            Times.Add(new Time() { Output = "Test data: 50 seconds" });
            Times.Add(new Time() { Output = "Test data: 40 minutes and 10 seconds" });

            context.Times.AddRange(Times);
            base.Seed(context);
        }
    }
}
