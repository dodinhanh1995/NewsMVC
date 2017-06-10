namespace News.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tin")]
    public partial class tin
    {
        [Key, DisplayName("Mã tin tức")]
        public int idTin { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên Tiêu đề"), DisplayName("Tiêu đề")]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [StringLength(255), DisplayName("Tiêu đề SEO")]
        public string TieuDe_KhongDau { get; set; }

        [StringLength(1000), Required(ErrorMessage = "Vui lòng nhập Tóm tắt"), DisplayName("Tóm tắt")]
        public string TomTat { get; set; }

        [DataType(DataType.Upload)]
        [StringLength(255), DisplayName("Hình ảnh")]
        public string urlHinh { get; set; }

        [DisplayName("Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngay { get; set; }

        [DisplayName("Mã tác giả")]
        public int idUser { get; set; }

        [Column(TypeName = "ntext"), DisplayName("Nội dung"), AllowHtml]
        public string Content { get; set; }

        [DisplayName("Mã loại tin")]
        public int idLT { get; set; }

        [DisplayName("Mã thể loại")]
        public int? idTL { get; set; }

        [DisplayName("Số lượt xem"), DefaultValue(0)]
        public int? SoLanXem { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Trang thái"), DisplayName("Trạng thái")]
        public int? AnHien { get; set; }

        public virtual loaitin loaitin { get; set; }

        public virtual theloai theloai { get; set; }

        public virtual user user { get; set; }
    }
}
