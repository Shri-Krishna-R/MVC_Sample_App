using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Ajmera.Models;

namespace MVC_Ajmera.Controllers
{
    public class AuthorController : Controller
    {
        /* private readonly MVC_AjmeraContext _context;

        public AuthorController(MVC_AjmeraContext context)
        {
            _context = context;
        }
        */

        // GET: AuthorController
        [Route("AuthorController")]
        public ActionResult Index()
        {
            MVC_AjmeraContext mVC_AjmeraContext = new MVC_AjmeraContext();
            List<Author> authorList = mVC_AjmeraContext.Authors.ToList();
            return View(authorList);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            MVC_AjmeraContext mVC_AjmeraContext = new MVC_AjmeraContext();
            List<Author> author = mVC_AjmeraContext.Authors.Where(x => x.Authorid == id).ToList();

            return View(author);
        }
        [Route("AuthorController/Create")]
        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AuthorController/Create")]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                MVC_AjmeraContext context = new MVC_AjmeraContext();
                Author author1 = new Author();
                author1.Authorid = Convert.ToInt32(collection["Authorid"]);
                author1.AuthorName = collection["AuthorName"];
                context.Authors.Add(author1);
                context.SaveChanges();
                                
                    return RedirectToAction(nameof(Index));
                }

            return View();

        }
       

    

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            MVC_AjmeraContext context = new MVC_AjmeraContext();
            Author authors = context.Authors.First(x => x.Authorid == id);
            return View(authors);
            
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                MVC_AjmeraContext context = new MVC_AjmeraContext();
                Author author = new Author();
                author.Authorid = Convert.ToInt32(collection["Authorid"]);
                author.AuthorName = collection["AuthorName"];
                context.Authors.Update(author);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            MVC_AjmeraContext context = new MVC_AjmeraContext();
            Author authors = context.Authors.First(x => x.Authorid == id);
            List<Book> book = context.Books.Where(x => x.AuthorId == id).ToList();
            if (book.Count != 0)
            {
                return RedirectToAction("BookAvailable");
            }
            return View(authors);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                MVC_AjmeraContext context = new MVC_AjmeraContext();
                Author author = new Author();
                author.Authorid = Convert.ToInt32(collection["Authorid"]);
                author = context.Authors.Find(id);
                context.Authors.Remove(author);
                context.SaveChanges();           

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BookAvailable()
        {
            return View();
        }
    }
}

