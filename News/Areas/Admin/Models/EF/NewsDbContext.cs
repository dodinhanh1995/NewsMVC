namespace News.Areas.Admin.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("name=NewsDbContext")
        {
        }

        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<loaitin> loaitins { get; set; }
        public virtual DbSet<quangcao> quangcaos { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<tin> tins { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<comment>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<loaitin>()
                .HasMany(e => e.tins)
                .WithRequired(e => e.loaitin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<theloai>()
                .HasMany(e => e.loaitins)
                .WithRequired(e => e.theloai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.tins)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
