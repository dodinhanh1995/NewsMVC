using News.Areas.Admin.Models.EF;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace News.Models
{
    public class DetailModel<T>
    {
        private NewsDbContext db = new NewsDbContext();

        public List<T> GetDataDetail(string action, int tinID)
        {
            object[] param = new object[]
            {
                new SqlParameter("@action", action),
                new SqlParameter("@tinID", tinID)
            };
            return db.Database.SqlQuery<T>("sp_GetDataDetail @action, @tinID", param).ToList();
        }

        public tin GetSingle(int tinID)
        {
            return GetDataDetail("GetSingleDetail", tinID).SingleOrDefault() as tin;
        }

        public loaitin GetType(int tinID)
        {
            return GetDataDetail("GetType", tinID).SingleOrDefault() as loaitin;
        }
    }
}