using MVCSample.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class issueController : Controller
    {
        private managementEntities db = new managementEntities();
        // GET: issue
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult issue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult issue(string STUDENT_NAME,string SEMESTER,string BOOK_NAME,string ISSUE_DATE,string RETURN_DATE)
        {
            int semester_ = Convert.ToInt32(SEMESTER);
            ObjectParameter output = new ObjectParameter("V_OUT", typeof(int));
            var result = db.P_ISSUE(STUDENT_NAME, semester_, BOOK_NAME, ISSUE_DATE, RETURN_DATE, output);
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
        public ActionResult issuelist()
        {
            return View(db.P_GET_ISSUE().ToList());
        }
    }
}