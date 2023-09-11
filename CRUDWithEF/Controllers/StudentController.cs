using CRUDWithEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithEF.Controllers
{
    public class StudentController : Controller
    {
        
            ApplicationDbContext context;
            StudentCrud crud;

            public StudentController(ApplicationDbContext context)
            {
                this.context = context;
                crud = new StudentCrud(this.context);

            }
            // GET: BookController
            public ActionResult Index()
            {
                return View(crud.GetStudents());
            }

            // GET: BookController/Details/5
            public ActionResult Details(int id)
            {
                return View(crud.GetStudentById(id));
            }

            // GET: BookController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: BookController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Student student)
            {
                try
                {
                    int result = crud.AddStudent(student);
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

            // GET: BookController/Edit/5
            public ActionResult Edit(int id)
            {
                return View(crud.GetStudentById(id));
            }

            // POST: BookController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Student student)
            {
                try
                {
                    int result = crud.UpdateStudent(student);
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
                return View(crud.GetStudentById(id));
            }

            // POST: BookController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            [ActionName("Delete")]
            public ActionResult DeleteConfirm(int id)
            {
                try
                {
                    int result = crud.DeleteStudent(id);
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
