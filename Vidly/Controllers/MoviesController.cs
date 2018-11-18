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

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id==0)
            {
                db.Movies.Add(movie);
            }

            /*
             * This is used for update movie | nazmulhyder
             */
            else
            {
                var takeMovie = db.Movies.First(x => x.Id == movie.Id);
                takeMovie.Name = movie.Name;
                takeMovie.DateAdded = movie.DateAdded;
                takeMovie.ReleaseDate = movie.ReleaseDate;
                takeMovie.Genre = movie.Genre;
                takeMovie.NumberInStock = movie.NumberInStock;
            }
            
            db.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {

            var getGenre = db.Genres.ToList();
            var viewModel = new MovieVM()
            {
                Genres = getGenre
            };
            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var retriveintoDB = db.Movies.FirstOrDefault(x => x.Id == id);
            if (retriveintoDB == null)
            {
                return HttpNotFound();
            }

            var movie = new MovieVM()
            {
                Movie = retriveintoDB,
                Genres = db.Genres.ToList()

            };

            return View("MovieForm", movie);

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