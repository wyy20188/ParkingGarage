using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5.DAL;
using MVC5.Models;
using PagedList;

namespace MVC5.Controllers
{
    public class UserTestController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Users
        public ActionResult Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if(searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var users = from u in db.Users
                        select u;
            if(!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                default:
                    users = users.OrderBy(u => u.UserName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber,pageSize));
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
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

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,EmailAddress,PassWord")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Users/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,EmailAddress,PassWord")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

/*using MVC5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;
using System.Data.Entity;

namespace MVC5.Controllers
{
    public class UserController : Controller
    {
        private AccountContext db = new AccountContext();
        // GET: User
        public ActionResult Index()
        {
            return View(db.Users);
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["InputEmail"];
            string password = fc["InputPassword"];
            //var user = db.Users.Where(b => b.EmailAddress == email & b.PassWord == password);
            //if (user.Count() > 0)
            //{
            //    ViewBag.LoginState = email + "登陆成功";
            //}
            //else
            //{
            //    ViewBag.LoginState = email + "该用户不存在";
            //}
            //var users = db.Users.Where(u => u.UserName == "fcj");
            //var users = db.Users.OrderBy(u => u.UserName).Skip(0).Take(1); //排序和分页查询
            //var num = db.Users.Count(); //查询总数
            //var minID = db.Users.Min(u => u.ID); //查询最小ID
            //


            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        //查询用户和角色
        public ActionResult Details(int id)
        {
            User User = db.Users.Find(id);
            return View(User);
        }
        //创建用户
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //修改用户
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            db.Entry(User).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //删除用户
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

    */