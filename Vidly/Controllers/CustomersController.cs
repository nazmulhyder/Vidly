using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.VidlyDbContext;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private VidlyDbContext.VidlyDbContext db;
        public CustomersController()
        {
            db = new VidlyDbContext.VidlyDbContext();
        }

        public ActionResult New()
        {

            var membershipTypes = db.MembershipTypes.ToList();
            var customerVm = new CustomerVM
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",customerVm);

        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id==0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var cusInDb = db.Customers.First(c => c.Id == customer.Id);
                cusInDb.Name = customer.Name;
                cusInDb.BirthDate = customer.BirthDate;
                cusInDb.IsSubscribeToNewsLatter = customer.IsSubscribeToNewsLatter;
                cusInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            
            

            db.SaveChanges();
            return RedirectToAction("Index","Customers");
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

        public ActionResult Edit(int Id)
        {
            var editCustomer = db.Customers.FirstOrDefault(c => c.Id == Id);
            if (editCustomer == null)
            {
                return HttpNotFound();
            }

            var customerVM = new CustomerVM()
            {
                Customer = editCustomer,
                MembershipTypes = db.MembershipTypes.ToList()

            };

            return View("CustomerForm",customerVM);

        }

        
    }
}