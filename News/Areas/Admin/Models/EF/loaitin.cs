namespace News.Areas.Admin.Models.EF
{
    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

    [Table("loaitin")]
    public partial class loaitin
    {
        public loaitin()
        {
            tins = new HashSet<tin>();
        }

        [Key]
        public int idLT { get; set; }

        [Required(ErrorMessage="Vui lòng nhập tên Loại tin!")]
        [StringLength(50), DisplayName("Tên loại tin")]
        public string Ten { get; set; }

        [StringLength(50), DisplayName("Tên loại tin SEO")]
        public string Ten_KhongDau { get; set; }

        [DisplayName("Thứ tự"), Range(1, 100, ErrorMessage="Thứ tự phải từ 1 đến 100"), Required(ErrorMessage="Vui lòng nhập Thứ tự!")]
        public int ThuTu { get; set; }

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage = "Vui lòng chọn Trạng thái")]
        public int AnHien { get; set; }

        [DisplayName("Mã thể loại")]
        public int idTL { get; set; }

        public virtual ICollection<tin> tins { get; set; }

        public virtual theloai theloai { get; set; }
    }
}
