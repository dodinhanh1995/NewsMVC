using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using News.Areas.Admin.Models.EF;
using News.Common;
using System.IO;

namespace News.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        private NewsDbContext db = new NewsDbContext();

        // GET: Admin/News
        public ActionResult Index()
        {
            var tins = db.tins.Include(t => t.loaitin).Include(t => t.theloai).Include(t => t.user);
            return View(tins.ToList());
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.idLT = new SelectList(db.loaitins, "idLT", "Ten");
            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL");
            ViewBag.idUser = new SelectList(db.users, "idUser", "HoTen");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "idTin,TieuDe,TieuDe_KhongDau,TomTat,urlHinh,idUser,Content, idLT,idTL,AnHien")] tin news, HttpPostedFileBase urlHinh)
        {
            if (ModelState.IsValid)
            {
                
                if (urlHinh.ContentLength <= 0)
                {
                    return View(news);
                }
                
                    string _FileName = Path.GetFileName(urlHinh.FileName) + DateTime.Now.ToString("ddMMyyyyhmi");
                    string _path = Path.Combine(Server.MapPath("~/Assets/upload/tintuc/"), _FileName);
                    urlHinh.SaveAs(_path);

                news.TieuDe_KhongDau = StringHelper.ToUnsignString(news.TieuDe);
                news.idUser = Convert.ToInt32(Session["ID"]);
                news.urlHinh = _FileName;
                news.Ngay = DateTime.Now;
                db.tins.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLT = new SelectList(db.loaitins, "idLT", "Ten", news.idLT);
            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL", news.idTL);
            ViewBag.idUser = new SelectList(db.users, "idUser", "HoTen", news.idUser);
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tin tin = db.tins.Find(id);
            if (tin == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLT = new SelectList(db.loaitins, "idLT", "Ten", tin.idLT);
            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL", tin.idTL);
            return View(tin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tin news, HttpPostedFileBase urlHinh)
        {
            if (ModelState.IsValid)
            {
                string _FileName;
                string _OldFile = (from t in db.tins
                                where t.idTin == news.idTin
                                select t.urlHinh).Single();

                if (urlHinh != null)
                {
                    _FileName = Path.GetFileName(urlHinh.FileName) + DateTime.Now.ToString("ddMMyyyyhmi");
                    string _path = Server.MapPath("~/Assets/upload/tintuc/");
                    if (System.IO.File.Exists(_path + _OldFile))
                    {
                        System.IO.File.Delete(_path + _OldFile);
                    }
                    urlHinh.SaveAs(Path.Combine(_path,_FileName));

                }
                else
                {
                    _FileName = _OldFile;
                }
                
                news.urlHinh = _FileName;
                news.TieuDe_KhongDau = StringHelper.ToUnsignString(news.TieuDe);
                news.idUser = Convert.ToInt32(Session["ID"]);
                news.Ngay = DateTime.Now;

                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLT = new SelectList(db.loaitins, "idLT", "Ten", news.idLT);
            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL", news.idTL);
            return View(news);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

                tin tin = db.tins.Find(id);

                string _path = Server.MapPath("~/Assets/upload/tintuc/");
                if (System.IO.File.Exists(_path + tin.urlHinh))
                {
                    System.IO.File.Delete(_path + tin.urlHinh);
                }
                db.tins.Remove(tin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { }
            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
