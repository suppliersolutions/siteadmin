using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteAdmin.Models;

namespace SiteAdmin.Controllers
{
    public class tblSuppliersController : Controller
    {
        private SupplierLiveEntities2 db = new SupplierLiveEntities2();

        // GET: tblSuppliers
        public ActionResult Index()
        {
            return View(db.tblSuppliers.ToList());
        }

        // GET: tblSuppliers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSupplier tblSupplier = db.tblSuppliers.Find(id);
            if (tblSupplier == null)
            {
                return HttpNotFound();
            }
            return View(tblSupplier);
        }

        // GET: tblSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,CompanyName,ContactName,ContactEmail,ContactPassword,Address1,Address2,City,State,Zip,Phone,Fax,WebAddress,OrdersEmail,vdn,EmailCCInfo,AllowAnonymous,BuyerRegistration,BuyerRegistrationEmail,BCCSuperAdmin,decimal,UPSTools,AdminLocale,TimeOffSet,Workflow,Invoicing,QtyPricingTable,DraftCart,Notes,Attributes,InventoryUpload,MarketingLists,CustomPages,ApplicationType,IsNotifyOrderError")] tblSupplier tblSupplier)
        {
            if (ModelState.IsValid)
            {
                db.tblSuppliers.Add(tblSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSupplier);
        }

        // GET: tblSuppliers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSupplier tblSupplier = db.tblSuppliers.Find(id);
            if (tblSupplier == null)
            {
                return HttpNotFound();
            }
            return View(tblSupplier);
        }

        // POST: tblSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,CompanyName,ContactName,ContactEmail,ContactPassword,Address1,Address2,City,State,Zip,Phone,Fax,WebAddress,OrdersEmail,vdn,EmailCCInfo,AllowAnonymous,BuyerRegistration,BuyerRegistrationEmail,BCCSuperAdmin,decimal,UPSTools,AdminLocale,TimeOffSet,Workflow,Invoicing,QtyPricingTable,DraftCart,Notes,Attributes,InventoryUpload,MarketingLists,CustomPages,ApplicationType,IsNotifyOrderError")] tblSupplier tblSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSupplier);
        }

        // GET: tblSuppliers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSupplier tblSupplier = db.tblSuppliers.Find(id);
            if (tblSupplier == null)
            {
                return HttpNotFound();
            }
            return View(tblSupplier);
        }

        // POST: tblSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblSupplier tblSupplier = db.tblSuppliers.Find(id);
            db.tblSuppliers.Remove(tblSupplier);
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
