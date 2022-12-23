using Service;
using Common;
using System.Web.Mvc;
using Model.Domain;
using FrontEnd.App_Start;
using Model.Custom;

namespace FrontEnd.Controllers
{
    public class PanelController : Controller
    {
        private IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private IContactService _contactService = DependecyFactory.GetInstance<IContactService>();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Category(int id = 0)
        {
            return Json(null);
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUsers(AnexGRID grid)
        {
            return Json(
                _userService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult ContactSave(ContactCard model)
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
    }
}