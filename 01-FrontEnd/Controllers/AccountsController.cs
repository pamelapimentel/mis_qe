using Common;
using Service;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEnd.App_Start;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private IAccountsService _accountsService = DependecyFactory.GetInstance<IAccountsService>();
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int id = 0, int id_vista = 0)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.IdList = id;
            ViewBag.Controlador = id_vista;
            return View(_accountsService.Detail(id));
        }

        [HttpPost]
        public JsonResult GetAccounts(AnexGRID grid, int id)
        {
            return Json(
                _accountsService.GetAll(grid, id)
            );
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id, int id_vista = 0)
        {
            ViewBag.Controlador = 1;
            return View(
                _accountsService.Detail(id)
            );
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
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

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accounts/Edit/5
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

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accounts/Delete/5
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
