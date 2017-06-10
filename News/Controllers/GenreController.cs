using News.Areas.Admin.Models.EF;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace News.Controllers
{
    public class GenreController : Controller
    {
        // GET: Type
        NewsDbContext db = new NewsDbContext();

        public ActionResult Index(int? genreID, int? page)
        {

            var type = (from t in db.tins
                       where t.idLT == genreID
                       select t);

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(type.OrderBy(x=>x.idLT).ToPagedList(pageNumber, pageSize));
        }
    }
}