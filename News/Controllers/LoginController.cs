using News.Areas.Admin.Models.EF;
using News.Common;
using System.Linq;
using System.Web.Mvc;

namespace News.Controllers
{
    public class LoginController : Controller
    {
        private NewsDbContext db = new NewsDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection f)
        {
            string username = f["txtUsername"].ToString();
            string password = Encryptor.MD5Hash(f["txtPassword"].ToString());
            user user = db.users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {
                Session.Add("ACCOUNT_SESSION", user);
                Session.Timeout = 720;
                return RedirectToAction("Index", "Admin/Home");
            }
            ViewBag.Notify = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }

        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}