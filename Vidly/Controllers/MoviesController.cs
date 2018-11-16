using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        VidlyDbContext.VidlyDbContext db = new VidlyDbContext.VidlyDbContext();
        // GET: Movies/Index
        public ActionResult Index()
        {
            var movies = db.Movies.Include(x=>x.Genre).ToList();
            return View(movies);

        }

        public ActionResult Details(int Id)
        {
            var movies = db.Movies.Include(m=>m.Genre).FirstOrDefault(x=>x.Id==Id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        
        

        
    }
}