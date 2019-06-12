using highchart_line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using highchart_line.Models;
using System.Collections;
using System.Globalization;

namespace highchart_line.Controllers

{       public class HomeController : Controller
    {
     
        public CarPark_SystemEntities9 db = new CarPark_SystemEntities9();

        // GET: inout_time_off
        public ActionResult LineChart()
        {

            var offcap = (from x in db.C3in1data where x.Location == "Office" select x.Capacity);
            var shoppingcap = (from x in db.C3in1data where x.Location == "Shopping" select x.Capacity);
            var rescap = (from x in db.C3in1data where x.Location == "Residential B" select x.Capacity);

            // var offcap = db.C3in1data.Select(x => x.Capacity);
            //var offdt = db.C3in1data.Select(x => x.Date_Time);

            var offdt = (from x in db.C3in1data where x.Location == "Office" select x.Date_Time);
            var shoppingdt = (from x in db.C3in1data where x.Location == "Shopping" select x.Date_Time);
            var resdt = (from x in db.C3in1data where x.Location == "Residential B" select x.Date_Time);




            ViewBag.offCAP = offcap;
            ViewBag.shoppingCAP = shoppingcap;
            ViewBag.resCAP = rescap;

            ViewBag.offDT = offdt;
            ViewBag.shoppingDT = shoppingdt;
            ViewBag.resDT = resdt;

            return View(db.C3in1data.ToList());

            
        }
      public ActionResult avgsty()
        {

 
           var loc = db.C3build.Select(x => x.Location).Distinct();
            var min = db.C3build.Select(x => x.avg_sty).Where(y => y != null).ToList();

            ViewBag.LOC = loc;
            ViewBag.MIN =min;


            return View(db.C3build.ToList());


       }

        public ActionResult Contact()
        {
         return View(db.inout_time_off.ToList());
        }
    }
}