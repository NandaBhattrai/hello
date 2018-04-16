using System.Web.Mvc;
using MVCSample.Models;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace MVCSample.Controllers
{
    public class publisherController : Controller
    {
        private managementEntities db = new managementEntities();
        // GET: publisher
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult publisher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult publisher(string PUBLISHER_NAME)
        {
            ObjectParameter output = new ObjectParameter("V_OUT", typeof(int));
            var result = db.P_PUBLISHER(PUBLISHER_NAME, output);
            if (result.ToString() == "1")
            {
                ViewBag.message = true;
                ViewBag.errormessage = "unsuccessfully";
            }
            else
            {
                ViewBag.message = true;
                ViewBag.errormessage = "successfully";
            }
            return View();
        }
        public ActionResult publisherlist()
        {
            return View(db.P_GET_PUBLISHER().ToList());
        }
    }
}