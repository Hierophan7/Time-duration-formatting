using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculations;

namespace Task_1
{
    class Program
    {
        static int formatDuration;
        static void Main(string[] args)
        {
            formatDuration = 0;
            using (TimeContext db = new TimeContext())
            {
                getLastItems(db);
                Console.Write("Enter your time in seconds: ");
                while (!int.TryParse(Console.ReadLine(), out formatDuration))
                    Console.WriteLine("Please, use integer for time display.");
                saveToDB(db, new Time() { Output = TimeCalculations.Calculations(formatDuration) });
            }
        }

        static void getLastItems(TimeContext db)
        {
            var times = db.Times.ToList().Reverse<Time>().Take(5).Reverse();
            Console.WriteLine("Last items in data base: ");
            foreach (Time u in times)
            {
                Console.WriteLine("{0}. {1}", u.Id, u.Output);
            }
        }

        static void saveToDB(TimeContext db, Time time)
        {
            Console.WriteLine(time.Output);
            db.Times.Add(time);
            db.SaveChanges();
            Console.WriteLine("Data was successfully saved!");
        }
    }
}
