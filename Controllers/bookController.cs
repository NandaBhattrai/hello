using MVCSample.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class bookController : Controller
    {
        private managementEntities db = new managementEntities();
        // GET: book
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult bookregister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bookregister(string BOOK_NAME, string AUTHOR_NAME, string PUBLISHER_NAME, string edition, string semester, string NUMBER_OF_COPIES, string image)
        {
            int semester_ = Convert.ToInt32(semester);
            int noc_ = Convert.ToInt32(NUMBER_OF_COPIES);
            ObjectParameter output = new ObjectParameter("V_OUT", typeof(int));
            db.P_REGISTER(BOOK_NAME, AUTHOR_NAME, PUBLISHER_NAME, edition,semester_,noc_,image,output);
            if (output.Value.ToString() == "1")
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

        public ActionResult booklist()
        {
            return View(db.P_GET_REGISTER().ToList());
        }
        public ActionResult Edit(int id)
        {
            var model = db.TBL_BREGISTER.Where(X=>X.BOOK_ID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id,string BOOK_NAME,string AUTHOR_NAME,string PUBLISHER_NAME,string EDITION,string SEMESTER,string NUMBER_OF_COPIES,string IMAGE)
        {
            int semester_ = Convert.ToInt32(SEMESTER);
            int noc_ = Convert.ToInt32(NUMBER_OF_COPIES);
            ObjectParameter output = new ObjectParameter("V_OUT", typeof(int));
            db.P_UPDATE_REGISTER(id,BOOK_NAME, AUTHOR_NAME, PUBLISHER_NAME, EDITION, semester_, noc_, IMAGE, output);
            if (output.Value.ToString() == "1")
            {
                ViewBag.message = true;
                ViewBag.errormessage = "unsuccessfully";
            }
            else
            {
                ViewBag.message = true;
                ViewBag.errormessage = "successfully";
                return RedirectToAction("booklist");
            }
            return RedirectToAction("booklist");
        }
        
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                ViewBag.message = true;
                ViewBag.errormessage = "Sorry Something Went Wrong";
                return RedirectToAction("booklist");
            }
            else
            {
                ObjectParameter output = new ObjectParameter("V_OUT", typeof(int));
                db.P_DELETE_REGISTER(id, output);
                if (output.Value.ToString() == "1")
                {
                    ViewBag.message = true;
                    ViewBag.errormessage = "Sorry Something Went Wrong";
                }
                else
                {
                    ViewBag.message = true;
                    ViewBag.errormessage = "successfully deleted";
                    return RedirectToAction("booklist");
                }
            }
                       
            return RedirectToAction("booklist");
        }
       
        public ActionResult Details(int id)
        {
            var model = db.TBL_BREGISTER.Where(X => X.BOOK_ID == id).FirstOrDefault();
            return View(model);
        }
      
    }
}
    