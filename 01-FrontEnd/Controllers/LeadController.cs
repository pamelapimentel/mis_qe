using Common;
using Model.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class LeadController : Controller
    {
        private ILeadService _leadService = DependecyFactory.GetInstance<ILeadService>();
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveLead(Lead model)
        {
            return Json(
                _leadService.InsertOrUpdate(model));
        }

        // GET: Lead/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lead/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lead/Create
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

        // GET: Lead/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lead/Edit/5
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

        // GET: Lead/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lead/Delete/5
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
