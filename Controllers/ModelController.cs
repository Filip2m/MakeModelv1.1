using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeModel.Models;

namespace MakeModel.Controllers
{
    public class ModelController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        //
        // GET: /Model/

        public ActionResult Index()
        {
            return View(db.VehicleModels.ToList());
        }

        //
        // GET: /Model/Details/5

        public ActionResult Details(int id = 0)
        {
            VehicleModel vehiclemodel = db.VehicleModels.Find(id);
            if (vehiclemodel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemodel);
        }

        //
        // GET: /Model/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Model/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModel vehiclemodel)
        {
            if (ModelState.IsValid)
            {
                db.VehicleModels.Add(vehiclemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiclemodel);
        }

        //
        // GET: /Model/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VehicleModel vehiclemodel = db.VehicleModels.Find(id);
            if (vehiclemodel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemodel);
        }

        //
        // POST: /Model/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleModel vehiclemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiclemodel);
        }

        //
        // GET: /Model/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VehicleModel vehiclemodel = db.VehicleModels.Find(id);
            if (vehiclemodel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemodel);
        }

        //
        // POST: /Model/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleModel vehiclemodel = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehiclemodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}