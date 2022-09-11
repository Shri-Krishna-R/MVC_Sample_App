using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Ajmera.Models;
using NuGet.Protocol.Plugins;

namespace MVC_Ajmera.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        [Route("BookController")]
        public ActionResult Index()
        {
            MVC_AjmeraContext mVC_AjmeraContext = new MVC_AjmeraContext();
            List<Book> bookList = mVC_AjmeraContext.Books.ToList();
            return View(bookList);
           
        }
        
        public ActionResult Details(int id)
        {
            MVC_AjmeraContext mVC_AjmeraContext = new MVC_AjmeraContext();
            List<Book> books = mVC_AjmeraContext.Books.Where(x => x.Bookid == id).ToList();

            return View(books);
        
        }

      
        public ActionResult BookDetails(int authorid, string authorname)
        {
            MVC_AjmeraContext context = new MVC_AjmeraContext();
            List<Book> books = context.Books.Where(x =>x.AuthorId == authorid & x.Author == authorname).ToList();
            if(books.Count > 0)
            {
                return View(books);
            }
           
            return RedirectToAction("NoBook","Book");
        }

        public ActionResult Nobook()
        {
            return View();
        }
        public ActionResult NewBook(int authorid, String Authorname )
        {
            MVC_AjmeraContext context = new MVC_AjmeraContext();
            Book bk = new Book();
            bk.Author = Authorname;
            return View(bk);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewBook(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                MVC_AjmeraContext context = new MVC_AjmeraContext();
                Book bk = new Book();
                bk.Bookid = Convert.ToInt32(collection["Bookid"]);
                bk.Booktitle = (collection["Booktitle"]);
                bk.Author = (collection["Author"]);
                bk.AuthorId = Convert.ToInt32(collection["AuthorId"]);
                context.Books.Add(bk);
               
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            MVC_AjmeraContext context = new MVC_AjmeraContext();
            
            Book Bks = context.Books.First(x => x.Bookid == id);
            return View(Bks);
          

        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                MVC_AjmeraContext context = new MVC_AjmeraContext();
                Book author = new Book();
                author.Bookid = Convert.ToInt32(collection["BookId"]);
                author.Booktitle = (collection["Booktitle"]);
                author.Author = (collection["Author"]);
                author.AuthorId = Convert.ToInt32(collection["AuthorId"]);
                context.Books.Update(author);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            MVC_AjmeraContext context = new MVC_AjmeraContext();
            
            Book bks = context.Books.First(x => x.Bookid == id);

            return View(bks);
            
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                MVC_AjmeraContext context = new MVC_AjmeraContext();
                Book author = new Book();
                author.Bookid = Convert.ToInt32(collection["Bookid"]);
                author = context.Books.Find(id);
                context.Books.Remove(author);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }
    }
}
