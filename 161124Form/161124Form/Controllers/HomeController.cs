using _161124Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161124Form.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ViewResult RSVP()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RSVP(GuestResponse g)
        {
            if (ModelState.IsValid == true)
            {
                return View("Thanks", g);
            }

            return View();
        }
    }
}