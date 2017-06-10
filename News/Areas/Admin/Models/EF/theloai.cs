namespace News.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("theloai")]
    public partial class theloai
    {
        public theloai()
        {
            loaitins = new HashSet<loaitin>();
            tins = new HashSet<tin>();
        }

        [Key, DisplayName("Mã thể loại")]
        public int idTL { get; set; }

        [Required(ErrorMessage="Vui lòng nhập Tên thể loại!"), DisplayName("Tên thể loại")]
        [StringLength(50), Index(IsUnique=true)]
        public string TenTL { get; set;}

        [DisplayName("Tên thể loại SEO")]
        [StringLength(50)]
        public string TenTL_KhongDau { get; set; }

        [DisplayName("Thứ tự"), Range(1, 100, ErrorMessage=("Thứ tự phải từ 1 đến 100")), Required(ErrorMessage = "Vui lòng nhập số thứ tự!")]
        public int? ThuTu { get; set; }

        [DisplayName("Trạng thái"), Required(ErrorMessage="Vui lòng chọn Trạng thái")]
        public int? AnHien { get; set; }

        public virtual ICollection<loaitin> loaitins { get; set; }

        public virtual ICollection<tin> tins { get; set; }
    }
}
