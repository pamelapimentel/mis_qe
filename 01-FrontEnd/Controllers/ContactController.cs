using Common;
using Service;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEnd.App_Start;
using Model.Custom;
using FrontEnd.ViewModels;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private IContactService _contactService = DependecyFactory.GetInstance<IContactService>();
        private IAccountsService _accountService = DependecyFactory.GetInstance<IAccountsService>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int id = 0, int id_vista = 0)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.IdList = id;
            ViewBag.Controlador = id_vista;

            var model = new CreateContactPerAccount();
            model.Accounts = _accountService.GetAll();
            model.ContactCard = new ContactCard();
            return View(model);
        }

        //public ActionResult ListAccounts(int id = 0)
        //{
        //    ViewBag.Message = "Your application description page.";
        //    ViewBag.IdList = id;

        //    return View(_contactService.Detail(id));
        //}

        [HttpPost]
        public JsonResult GetContact(int id)
        {
            return Json(
                _contactService.Get(id)
            );
        }

        [HttpPost]
        public JsonResult GetContacts(AnexGRID grid)
        {
            return Json(
                _contactService.GetAll(grid)
            );
        }
        [HttpPost]
        public JsonResult ContactSave (ContactCard model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _contactService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            return Json(
                _contactService.Delete(id)
            );
        }

        public ActionResult Details(int id)
        {
            ViewBag.Controlador = 1;
            return View(
                _contactService.Detail(id)
            );
        }
    }
}