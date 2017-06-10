using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using News.Areas.Admin.Models.EF;
using News.Common;

namespace News.Areas.Admin.Controllers
{
    public class TypeController : BaseController
    {
        private NewsDbContext db = new NewsDbContext();

        // GET: Admin/Type
        public ActionResult Index()
        {
            var loaitins = db.loaitins.Include(l => l.theloai);
            return View(loaitins.ToList());
        }

        // GET: Admin/Type/Create
        public ActionResult Create()
        {
            ViewBag.idTL = new SelectList(db.theloais,"idTL", "TenTL");
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLT,Ten,Ten_KhongDau,ThuTu,AnHien,idTL")] loaitin type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isExists = (from t in db.loaitins
                                     where t.Ten == type.Ten
                                     select t).Count() > 0;
                    if (isExists) { ModelState.AddModelError("", "Tên loại tin đã tồn tại! Vui lòng nhập tên khác."); }
                    else
                    {
                        type.Ten_KhongDau = StringHelper.ToUnsignString(type.Ten);
                        db.loaitins.Add(type);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch { ModelState.AddModelError("", "Có lỗi khi thêm mới thông tin Loại tin! Vui lòng thử lại."); }

            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL", type.idTL);
            return View(type);
        }

        // GET: Admin/Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaitin type = db.loaitins.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL", type.idTL);
            return View(type);
        }

        // POST: Admin/Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, loaitin type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != null)
                    {
                        if (type.Ten_KhongDau == null)
                        {
                            ModelState.AddModelError("", "Vui lòng nhập tên Loại tin SEO!");
                        }
                        else
                        {
                            var t = db.loaitins.Find(id);
                            t.Ten = type.Ten;
                            t.Ten_KhongDau = StringHelper.ToUnsignString(type.Ten_KhongDau);
                            t.ThuTu = type.ThuTu;
                            t.AnHien = type.AnHien;
                            t.idTL = type.idTL;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi khi thêm mới thông tin Loại tin! Vui lòng thử lại.");
                
            }
            ViewBag.idTL = new SelectList(db.theloais, "idTL", "TenTL", type.idTL);
            return View(type);
        }

        // GET: Admin/Type/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
                db.loaitins.Remove(db.loaitins.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch { return HttpNotFound(); }
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
