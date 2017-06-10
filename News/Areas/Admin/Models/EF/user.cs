namespace News.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public user()
        {
            tins = new HashSet<tin>();
        }

        [Key]
        public int idUser { get; set; }

        [Required]
        [StringLength(70)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string Dienthoai { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDangKy { get; set; }

        public int idGroup { get; set; }

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        public int? GioiTinh { get; set; }

        public string Avatar { get; set; }

        public int? Active { get; set; }

        public virtual ICollection<tin> tins { get; set; }
    }
}
