using News.Areas.Admin.Models.EF;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace News.Models
{
    public class HomeModel<T>
    {
        private NewsDbContext db = new NewsDbContext();

        public List<T> GetListMain(string action, int quantity = 0, int theLoaiID = 0, int notTop1 = 0)
        {
            object[] param = new object[]
            {
                new SqlParameter("@action", action),
                new SqlParameter("@quantity", quantity),
                new SqlParameter("@theLoaiID", theLoaiID),
                new SqlParameter("@notTop1", notTop1)
            };
            return db.Database.SqlQuery<T>("sp_GetHomeData @action, @quantity, @theLoaiID, @notTop1", param).ToList();
        }

        public List<theloai> GetMainMenu()
        {
            return GetListMain("GetMainMenu") as List<theloai>;
        }

        public List<loaitin> GetSubMenu(int theLoaiID)
        {
            return GetListMain("GetSubMenu", 0, theLoaiID) as List<loaitin>;
        }

        public List<tin> GetLastestNews(string action)
        {
            return GetListMain(action) as List<tin>;
        }

        public List<tin> GetFavourist(int theLoaiID, int quantity = 5, int notTop1 = 0)
        {
            return GetListMain("Favourist", quantity, theLoaiID, notTop1) as List<tin>;
        }
    }
}