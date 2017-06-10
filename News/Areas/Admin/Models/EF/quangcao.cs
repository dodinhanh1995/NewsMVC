namespace News.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quangcao")]
    public partial class quangcao
    {
        [Key]
        public int idQC { get; set; }

        public int vitri { get; set; }

        [Required]
        [StringLength(255)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        [Required]
        [StringLength(255)]
        public string urlHinh { get; set; }

        public int SoLanClick { get; set; }
    }
}
