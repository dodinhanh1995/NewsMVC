namespace News.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("comment")]
    public partial class comment
    {
        public int id { get; set; }

        [Required]
        [StringLength(120)]
        public string hoten { get; set; }

        [Required]
        [StringLength(120)]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string noidung { get; set; }

        [Required]
        public int idTin { get; set; }
    }
}
