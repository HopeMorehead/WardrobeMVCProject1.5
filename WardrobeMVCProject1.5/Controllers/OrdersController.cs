using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVCProject1._5.Models;

namespace WardrobeMVCProject1._5.Controllers
{
    public class OrdersController : Controller
    {
        private WardrobeMVCProjectEntities db = new WardrobeMVCProjectEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Accessory).Include(o => o.Bottom).Include(o => o.Sho).Include(o => o.Top);
            return View(orders.ToList());
        }



        public ActionResult PurchaseForOrder()
        {
            var orders = db.Orders.Include(o => o.Accessory).Include(o => o.Bottom).Include(o => o.Sho).Include(o => o.Top);
            return View(orders.ToList());
        }









        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoryID", "Photo");
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomID", "Photo");
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoeID", "Photo");
            ViewBag.TopsID = new SelectList(db.Tops, "TopID", "Photo");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerName,TopsID,BottomsID,ShoesID,AccessoriesID,Purchase")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoryID", "Photo", order.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomID", "Photo", order.BottomsID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoeID", "Photo", order.ShoesID);
            ViewBag.TopsID = new SelectList(db.Tops, "TopID", "Photo", order.TopsID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoryID", "Photo", order.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomID", "Photo", order.BottomsID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoeID", "Photo", order.ShoesID);
            ViewBag.TopsID = new SelectList(db.Tops, "TopID", "Photo", order.TopsID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerName,TopsID,BottomsID,ShoesID,AccessoriesID,Purchase")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoryID", "Photo", order.AccessoriesID);
            ViewBag.BottomsID = new SelectList(db.Bottoms, "BottomID", "Photo", order.BottomsID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoeID", "Photo", order.ShoesID);
            ViewBag.TopsID = new SelectList(db.Tops, "TopID", "Photo", order.TopsID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
