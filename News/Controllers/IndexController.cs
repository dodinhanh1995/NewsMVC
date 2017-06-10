using System.Web.Mvc;
using News.Models;
using News.Areas.Admin.Models.EF;

namespace News.Controllers
{
    public class IndexController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _Nav()
        {
            HomeModel<theloai> list = new HomeModel<theloai>();
            return PartialView(list.GetMainMenu());
        }

        [ChildActionOnly]
        public ActionResult _subNav(int theLoaiID)
        {
            HomeModel<loaitin> list = new HomeModel<loaitin>();
            return PartialView(list.GetSubMenu(theLoaiID));
        }

        [ChildActionOnly]
        public ActionResult _Slider()
        {
            return PartialView(new HomeModel<tin>().GetLastestNews("GetSlider"));
        }

        [ChildActionOnly]
        public ActionResult _LastestNews()
        {
            return PartialView(new HomeModel<tin>().GetLastestNews("LastestNews"));
        }

        [ChildActionOnly]
        public ActionResult _GetLife()
        {
            return PartialView(new HomeModel<tin>().GetFavourist(7));
        }

        public ActionResult _GetWorld()
        {
            return PartialView(new HomeModel<tin>().GetFavourist(2));
        }

        public ActionResult _GetCultural()
        {
            return PartialView(new HomeModel<tin>().GetFavourist(4, 6));
        }

        public ActionResult _GetSport()
        {
            return PartialView(new HomeModel<tin>().GetFavourist(5, 5, 1));
        }

        public ActionResult _GetLastestSport()
        {
            return PartialView(new HomeModel<tin>().GetFavourist(5, 1));
        }

        public ActionResult _GetNiceOfWeek()
        {
            return PartialView(new HomeModel<tin>().GetListMain("NiceOfWeek"));
        }

        public ActionResult _GetRightAdveritse()
        {
            return PartialView(new HomeModel<quangcao>().GetListMain("AdvertiseRight", 4));
        }

        public ActionResult _LeftFooter()
        {
            return PartialView(new HomeModel<theloai>().GetListMain("GetFooter", 3, 0, 3));
        }

        public ActionResult _MiddleFooter()
        {
            return PartialView(new HomeModel<theloai>().GetListMain("GetFooter", 3, 0, 6));
        }

        public ActionResult _RightFooter()
        {
            return PartialView(new HomeModel<theloai>().GetListMain("GetFooter", 3));
        }

        [ChildActionOnly]
        public ActionResult _subFooter(int theLoaiID)
        {
            return PartialView(new HomeModel<loaitin>().GetSubMenu(theLoaiID));
        }
    }
}