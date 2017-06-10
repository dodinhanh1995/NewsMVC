using News.Areas.Admin.Models.EF;
using System.Web.Mvc;

namespace News.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private NewsDbContext db = new NewsDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["ACCOUNT_SESSION"] != null)
            {
                user user = Session["ACCOUNT_SESSION"] as user;
                Session["ID"] = user.idUser;
                Session["DisplayName"] = user.HoTen;
                Session["GroupID"] = user.idGroup;
                Session["Avatar"] = user.Avatar;
            }
            return View();
        }
    }
}