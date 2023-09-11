using CRUDWithEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithEF.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext context;
        BookCrud crud;

        public BookController(ApplicationDbContext context)
        {
           this.context= context;
            crud = new BookCrud(this.context);
                
        }
        // GET: BookController
        public ActionResult Index()
        { 
            return View(crud.GetBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.GetBookById(id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = crud.AddBook(book);
                if (result==1)
                return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crud.GetBookById(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = crud.UpdateBook(book);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }

            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetBookById(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteBook(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }

            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
