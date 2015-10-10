using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMart.DAL;
using WebMart.Models;

namespace WebMart.Controllers
{
    public class TestOrderController : Controller
    {
        private WebMartContext db = new WebMartContext();

        // GET: TestOrder
        public ActionResult Index()
        {
            return View(db.TestOrders.ToList());
        }

        // GET: TestOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrder testOrder = db.TestOrders.Find(id);
            if (testOrder == null)
            {
                return HttpNotFound();
            }
            return View(testOrder);
        }

        // GET: TestOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public bool Create([Bind(Include = "CreditCardNumber,CreditCardPin")] TestOrder testOrder)
        {
            if (ModelState.IsValid)
            {
                db.TestOrders.Add(testOrder);
                db.SaveChanges();
         
                
                //return RedirectToAction("Index");
            }
            return true;
            //return View(testOrder);
        }

        // GET: TestOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrder testOrder = db.TestOrders.Find(id);
            if (testOrder == null)
            {
                return HttpNotFound();
            }
            return View(testOrder);
        }

        // POST: TestOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreditCardNumber,CreditCardPin")] TestOrder testOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testOrder);
        }

        // GET: TestOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrder testOrder = db.TestOrders.Find(id);
            if (testOrder == null)
            {
                return HttpNotFound();
            }
            return View(testOrder);
        }

        // POST: TestOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestOrder testOrder = db.TestOrders.Find(id);
            db.TestOrders.Remove(testOrder);
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
