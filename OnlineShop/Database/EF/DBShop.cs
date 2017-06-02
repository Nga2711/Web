namespace OnlineShop.Database.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBShop : DbContext
    {
        public DBShop()
            : base("name=DBShop5")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<chitietdonhang> chitietdonhangs { get; set; }
        public virtual DbSet<danhmuc> danhmucs { get; set; }
        public virtual DbSet<donhang> donhangs { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<loaisanpham> loaisanphams { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<sanpham_size_mausac> sanpham_size_mausac { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.tentruycap)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<chitietdonhang>()
                .Property(e => e.thanhtien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<donhang>()
                .Property(e => e.phivanchuyen)
                .HasPrecision(19, 4);

            modelBuilder.Entity<donhang>()
                .Property(e => e.tonggia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<donhang>()
                .HasMany(e => e.chitietdonhangs)
                .WithRequired(e => e.donhang)
                .HasForeignKey(e => e.hoadonma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .HasMany(e => e.donhangs)
                .WithRequired(e => e.khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.anh)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .HasMany(e => e.chitietdonhangs)
                .WithRequired(e => e.sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sanpham>()
                .HasMany(e => e.sanpham_size_mausac)
                .WithRequired(e => e.sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sanpham_size_mausac>()
                .Property(e => e.sizema)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham_size_mausac>()
                .Property(e => e.mauma)
                .IsUnicode(false);
        }
    }
}
