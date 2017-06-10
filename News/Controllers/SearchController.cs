using News.Areas.Admin.Models.EF;
using System.Linq;
using PagedList;
using System.Web.Mvc;

namespace News.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        NewsDbContext db = new NewsDbContext();
        public ActionResult Index(string s, string key, int? page)
        {
            var search = (from t in db.tins
                          select t).Where(x => x.TieuDe.Contains(s) || x.TieuDe_KhongDau.Contains(s));

            if (s != null) { page = 1; }
            else { s = key; }

            ViewBag.CurrentFilter = s;

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(search.OrderBy(x => x.idLT).ToPagedList(pageNumber, pageSize));
        }
    }
}