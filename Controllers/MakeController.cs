﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeModel.Models;

namespace MakeModel.Controllers
{
    public class MakeController : Controller
    {
        private MakeDBContext db = new MakeDBContext();

        //
        // GET: /Make/

        public ActionResult Index()
        {
            return View(db.VehicleMakes.ToList());
        }

        //
        // GET: /Make/Details/5

        public ActionResult Details(int? id)
        {
            VehicleMake vehiclemake = db.VehicleMakes.Find(id);
            if (vehiclemake == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemake);
        }

        //
        // GET: /Make/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Make/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleMake vehiclemake)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMakes.Add(vehiclemake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiclemake);
        }

        //
        // GET: /Make/Edit/5

        public ActionResult Edit(int? id)
        {
            VehicleMake vehiclemake = db.VehicleMakes.Find(id);
            if (vehiclemake == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemake);
        }

        //
        // POST: /Make/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleMake vehiclemake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclemake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiclemake);
        }

        //
        // GET: /Make/Delete/5

        public ActionResult Delete(int? id)
        {
            VehicleMake vehiclemake = db.VehicleMakes.Find(id);
            if (vehiclemake == null)
            {
                return HttpNotFound();
            }
            return View(vehiclemake);
        }

        //
        // POST: /Make/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleMake vehiclemake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehiclemake);
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