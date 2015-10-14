using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMart.DAL;
using Microsoft.AspNet.Identity;
using WebMart.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace WebMart.Controllers
{
    public class VendorUsersController : Controller
    {
        private WebAppEntities db = new WebAppEntities();
        private ApplicationUserManager _userManager;

        // GET: VendorUsers
        public ActionResult Index()
        {
            //var vendorUsers = db.VendorUsers.Include(v => v.Vendor);
            //TempData["VendorId"].ToString() != string.Empty
            int vendorId = 0;
            if (TempData["VendorId"] != null)
            {
                vendorId = Convert.ToInt32(TempData["VendorId"].ToString());
            }
            var vendorUsers = db.VendorUsers.Where(x => x.VendorId == vendorId).Include(v => v.Vendor);
            return View(vendorUsers.ToList());
        }

        // GET: VendorUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = db.VendorUsers.Find(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        // GET: VendorUsers/Create
        public ActionResult Create()
        {
            //ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name");
            ViewBag.VendorId = User.Identity.GetUserId();
            return View();
        }

        // POST: VendorUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Email,VendorId,AspId")] VendorUser vendorUser)
        {
            //if (ModelState.IsValid)
            //{
            //    db.VendorUsers.Add(vendorUser);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = vendorUser.Email, Email = vendorUser.Email };
                var result = UserManager.Create(user, "Test@123");
                var VendorUserId = db.AspNetUsers.Where(x => x.Email == vendorUser.Email).FirstOrDefault().Id;
                string userAspId = VendorUserId;
                vendorUser.AspId = userAspId;
                string loginId = User.Identity.GetUserId();

                int vendorId = db.Vendors.Where(x => x.AspId == loginId).FirstOrDefault().VendorId;
                vendorUser.VendorId = vendorId;

                db.VendorUsers.Add(vendorUser);
                db.SaveChanges();
                TempData["VendorId"] = vendorId;
                return RedirectToAction("Index");
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", vendorUser.VendorId);
            return View(vendorUser);
        }

        // GET: VendorUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = db.VendorUsers.Find(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", vendorUser.VendorId);
            return View(vendorUser);
        }

        // POST: VendorUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Phone,Email,VendorId,AspId")] VendorUser vendorUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", vendorUser.VendorId);
            return View(vendorUser);
        }

        // GET: VendorUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = db.VendorUsers.Find(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        // POST: VendorUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorUser vendorUser = db.VendorUsers.Find(id);
            db.VendorUsers.Remove(vendorUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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
