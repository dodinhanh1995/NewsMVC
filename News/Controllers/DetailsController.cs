using News.Areas.Admin.Models.EF;
using News.Models;
using System.Web.Mvc;

namespace News.Controllers
{
    public class DetailsController : Controller
    {
        // GET: DeTails
        public ActionResult Index(int id)
        {
            tin detail = new DetailModel<tin>().GetSingle(id);

            if(detail == null)
            {
                return RedirectToAction("Index", "Error");
            }
            return View(detail);
        }

        public ActionResult _GetType(int id)
        {
            return View(new DetailModel<loaitin>().GetType(id));
        }

        public ActionResult _GetRelated(int id)
        {
            return View(new DetailModel<tin>().GetDataDetail("GetRelatedNews", id));
        }
    }
}