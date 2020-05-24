using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculations;
using TimeDBContext;

namespace Web_interface.Controllers
{
    public class HomeController : Controller
    {
        private TimeContext db = new TimeContext();
        public ActionResult Index()
        {
            return View(db.Times.ToList().Reverse<Time>().Take(5).Reverse());
        }

        [HttpPost]
        public ActionResult TimeFormatting()
        {
            int formatDuration = 0;
            if (int.TryParse(Request["Time"].ToString(), out formatDuration))
            {
                ViewBag.OutputData = TimeCalculations.Calculations(formatDuration);
                db.Times.Add(new Time() { Output = ViewBag.OutputData });
                db.SaveChanges();
            }
            else
            {
                ViewBag.OutputData = "The number is too large or wrong input data.";
            }
            return View("Index", db.Times.ToList().Reverse<Time>().Take(5).Reverse());
        }
    }
}