using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program

    {
        static int formatDuration;
        static TimeContext db;
        static void Main(string[] args)
        {
            outputDB();
            Console.Write("Enter your time in seconds: ");
            formatDuration = 0;
            while (!int.TryParse(Console.ReadLine(), out formatDuration))
                Console.WriteLine("Please, use integer for time display.");
            saveToDB();
        }

        static void outputDB()
        {
            db = new TimeContext();
            if (db.Times.Count() == 0)
            {
                db.Times.Add(new Time() { Output = "Test data: 1 year, 50 minutes and 12 seconds" });
                db.Times.Add(new Time() { Output = "Test data: 50 seconds" });
                db.Times.Add(new Time() { Output = "Test data: 40 minutes and 10 seconds" });
                db.SaveChanges();
            }
            var times = db.Times.ToList().Reverse<Time>().Take(5).Reverse();
            Console.WriteLine("Last items in db: ");
            foreach (Time u in times)
            {
                Console.WriteLine("{0}. {1}", u.Id, u.Output);
            }
        }

        static void saveToDB()
        {
            db = new TimeContext();
            Formatting timeFormatting = new Formatting();
            Time time = new Time();
            Console.WriteLine(time.Output = timeFormatting.Calculations(formatDuration));
            db.Times.Add(time);
            db.SaveChanges();
            Console.WriteLine("Data was successfully saved!");
        }
    }
}
