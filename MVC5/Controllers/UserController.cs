using MVC5.DAL;
using System.Web.Mvc;
using MVC5.Models;
using System.Net;
using MVC5.ViewModels;
using System.Data.Entity;

namespace MVC5.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountInformation(int? id)
        {          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
           
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult MakeReservation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult ReservationInformation()
        {
            return View();
        }

        public ActionResult EditAccount(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            EditAccountViewModel eaViewModel = new EditAccountViewModel(user);
            return View(eaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount([Bind(Include = "ID,UserName,EmailAddress,PassWord")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult EditReservation()
        {
            return View();
        }
        public ActionResult CancelReservation()
        {
            return View();
        }
        public ActionResult Payments()
        {
            return View();
        }
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
