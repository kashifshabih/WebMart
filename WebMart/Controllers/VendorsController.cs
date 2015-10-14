using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMart.DAL;

namespace WebMart.Controllers
{
    [Authorize]
    public class VendorsController : Controller
    {
        private WebAppEntities db = new WebAppEntities();

        // GET: Vendors
        public ActionResult Index()
        {
            //var vendors = db.Vendors.Include(v => v.AspNetUser);
            //return View(vendors.ToList());
            var vendors = db.Vendors.Where(x => x.IsApproved == false).ToList();
            return View(vendors);
        }

        public ActionResult AllVendor(string status)
        {
            ViewBag.Status = (status == null ? "P" : status);
            if (status == null)
            {
                var vendors = db.Vendors.Where(x => x.IsApproved == false).ToList();
                return View(vendors);
            }
            else
            {
                return View();
            }
            
            //return View(); 
        }
        public ActionResult Approve(string AspId)
        {
            try
            {
                var myVendor = db.Vendors.Where(x => x.AspId == AspId).FirstOrDefault();
                var myUser = db.AspNetUsers.Where(x => x.Id == AspId).FirstOrDefault();
                myVendor.IsApproved = true;
                myUser.EmailConfirmed = true;

                db.Entry(myVendor).State = EntityState.Modified;
                db.Entry(myUser).State = EntityState.Modified;

                db.SaveChanges();

                TempData["Msg"] = "Approved Sucessfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Approve Failed: " + ex.Message;
                return RedirectToAction("Index");
            }

        }

        public ActionResult Reject(string AspId)
        {
            try
            {
                var myVendor = db.Vendors.Where(x => x.AspId == AspId).FirstOrDefault();
                var myUser = db.AspNetUsers.Where(x => x.Id == AspId).FirstOrDefault();
                myVendor.IsApproved = false;
                myUser.EmailConfirmed = false;

                db.Entry(myVendor).State = EntityState.Modified;
                db.Entry(myUser).State = EntityState.Modified;

                db.SaveChanges();

                TempData["Msg"] = "Rejected Sucessfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Reject Failed: " + ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public void ApproveOrRejectAll(List<String> Ids, String status)
        {
            try
            {
                //objBs.ApproveOrReject(Ids, status);
                ApproveOrRejectAllVendor(Ids, status);
                TempData["Msg"] = "Operation Sucessful";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Operation Failed: " + ex.Message;
            }
        }

        private void ApproveOrRejectAllVendor(List<string> Ids, string status)
        {
            try
            {
                foreach (var item in Ids)
                {
                    var myVendor = db.Vendors.Where(x => x.AspId == item).FirstOrDefault();
                    var myUser = db.AspNetUsers.Where(x => x.Id == item).FirstOrDefault();
                    myVendor.IsApproved = false;
                    myUser.EmailConfirmed = false;

                    db.Entry(myVendor).State = EntityState.Modified;
                    db.Entry(myUser).State = EntityState.Modified;

                    db.SaveChanges();
                    
                }
            }
            catch (Exception)
            {
                
                
            }
        }
        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            ViewBag.AspId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorId,Name,Address,Phone,CardCompany,CardType,CardNumber,SecurityCode,ExpireDate,CreatedBy,LastUpdate,AspId")] Vendor vendor, string optionsRadios)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Vendors.Add(vendor);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.AspId = new SelectList(db.AspNetUsers, "Id", "Email", vendor.AspId);
            //return View(vendor);

            string a = TempData["AspId"].ToString();
            string b = optionsRadios;
            if (ModelState.IsValid)
            {

                if (b == "Vendor")
                {
                    vendor.AspId = a;
                    db.Vendors.Add(vendor);
                }
                else if (b == "EndUser")
                {
                    EndUser user = new EndUser();
                    user.AspId = a;
                    user.Name = vendor.Name;
                    user.Address = vendor.Address;
                    user.Phone = vendor.Phone;
                    user.CardCompany = vendor.CardCompany;
                    user.CardType = vendor.CardType;
                    user.CardNumber = vendor.CardNumber;
                    user.SecurityCode = vendor.SecurityCode;
                    user.ExpireDate = vendor.ExpireDate;
                    user.CreatedBy = vendor.CreatedBy;

                    db.EndUsers.Add(user);
                }
                else
                { }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AspId = new SelectList(db.AspNetUsers, "Id", "Email", vendor.AspId);
            ViewBag.AspId = a;
            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspId = new SelectList(db.AspNetUsers, "Id", "Email", vendor.AspId);
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorId,Name,Address,Phone,CardCompany,CardType,CardNumber,SecurityCode,ExpireDate,CreatedBy,LastUpdate,AspId")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspId = new SelectList(db.AspNetUsers, "Id", "Email", vendor.AspId);
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
