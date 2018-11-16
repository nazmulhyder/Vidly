using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.VidlyDbContext;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private VidlyDbContext.VidlyDbContext db;
        public CustomersController()
        {
            db = new VidlyDbContext.VidlyDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //enable Eager loading
            var customer = db.Customers.Include(c=>c.MembershipType).ToList();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = db.Customers.Include(c=>c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

        }

        
    }
}