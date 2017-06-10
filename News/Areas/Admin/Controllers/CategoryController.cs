using News.Areas.Admin.Models.EF;
using News.Common;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace News.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        NewsDbContext db = new NewsDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.theloais.ToList());
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(theloai category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isExists = (from c in db.theloais
                                     where c.TenTL == category.TenTL
                                     select c.TenTL
                                      ).Count() > 0;
                    if (isExists)
                    {
                        ModelState.AddModelError("", "Tên thể loại đã tồn tại! Vui lòng nhập tên khác.");
                    }
                    else
                    {
                        category.TenTL_KhongDau = StringHelper.ToUnsignString(category.TenTL);

                        db.theloais.Add(category);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi khi thêm mới thông tin Thể loại! Vui lòng thử lại.");
            }
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.theloais.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, theloai category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != null)
                    {
                        if (category.TenTL_KhongDau == null)
                        {
                            ModelState.AddModelError("", "Vui lòng nhập tên Thể loại SEO!");
                            return View(category);
                        }
                        else
                        {
                            var cate = db.theloais.Find(id);
                            cate.TenTL = category.TenTL;
                            cate.TenTL_KhongDau = StringHelper.ToUnsignString(category.TenTL_KhongDau);
                            cate.ThuTu = category.ThuTu;
                            cate.AnHien = category.AnHien;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi khi thêm mới thông tin Thể loại! Vui lòng thử lại.");
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

                var type = (from t in db.loaitins
                                 where t.idTL == id
                            select t).ToList();
                for (int i = 0; i < type.Count(); i++)
                {
                    db.loaitins.Remove(type.First());
                }

                db.theloais.Remove(db.theloais.Find(id));
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
