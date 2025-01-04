using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace POS_DAL.Models
{
    public partial class POSContextDB : DbContext
    {
        public POSContextDB()
            : base("name=POSContextDB")
        {
        }

        public virtual DbSet<CTHD> CTHD { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.GIATIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAHD)
                .IsUnicode(false);


            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.GIATIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTHD)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
