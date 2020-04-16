using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int formatDuration = 0;
            try
            {
                formatDuration = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Try again.");
                return;
            }

            if (formatDuration <= 0)
            {
                Console.WriteLine("now");
                return;
            }

            int years, days, hours, minutes, seconds;
            StringBuilder answer = new StringBuilder();

            TimeSpan t = TimeSpan.FromSeconds(formatDuration);
            years = t.Days / 365;
            days = t.Days % 365;
            hours = t.Hours;
            minutes = t.Minutes;
            seconds = t.Seconds;

            if (years != 0)
            {
                answer.Append(years + ((years == 1) ? " year, " : " years, "));
            }
            if (days != 0)
            {
                answer.Append(days + ((days == 1) ? " day, " : " days, "));
            }
            if (hours != 0)
            {
                answer.Append(hours + ((hours == 1) ? " hour, " : " hours, "));
            }
            if (minutes != 0)
            {
                answer.Append(minutes + ((minutes == 1) ? " minute, " : " minutes, "));
            }
            if (seconds != 0)
            {
                answer.Append(seconds + ((seconds == 1) ? " second, " : " seconds, "));
            }

            answer.Length -= 2;
            int idx = answer.ToString().LastIndexOf(",");
            if (idx > 0) answer.Remove(idx, 2).Insert(idx, " and ");

            Console.WriteLine(answer);
        }
    }
}
