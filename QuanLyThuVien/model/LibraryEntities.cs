namespace QuanLyThuVien.model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryEntities : DbContext
    {
        public LibraryEntities()
            : base("name=library_db")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblDocGia> tblDocGias { get; set; }
        public virtual DbSet<tblLinhVuc> tblLinhVucs { get; set; }
        public virtual DbSet<tblNhanVien> tblNhanViens { get; set; }
        public virtual DbSet<tblNXB> tblNXBs { get; set; }
        public virtual DbSet<tblSach> tblSaches { get; set; }
        public virtual DbSet<tblTacGia> tblTacGias { get; set; }
        public virtual DbSet<tblMuon> tblMuons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.MADG)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.HOTEN)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.NGAYSINH)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.GIOITINH)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.LOP)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);

            modelBuilder.Entity<tblDocGia>()
                .HasMany(e => e.tblMuons)
                .WithRequired(e => e.tblDocGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblLinhVuc>()
                .Property(e => e.MaLv)
                .IsUnicode(false);

            modelBuilder.Entity<tblLinhVuc>()
                .Property(e => e.TenLv)
                .IsUnicode(false);

            modelBuilder.Entity<tblLinhVuc>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.QUYENHAN)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.TENNV)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.ChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<tblNhanVien>()
                .Property(e => e.Tuoi)
                .IsUnicode(false);

            modelBuilder.Entity<tblNXB>()
                .Property(e => e.MANXB)
                .IsUnicode(false);

            modelBuilder.Entity<tblNXB>()
                .Property(e => e.TENNXB)
                .IsUnicode(false);

            modelBuilder.Entity<tblNXB>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<tblNXB>()
                .Property(e => e.SODIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<tblNXB>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.TENSACH)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.MATG)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.MANXB)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.MaLv)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.NAMXB)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.NGAYNHAP)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);

            modelBuilder.Entity<tblSach>()
                .HasMany(e => e.tblMuons)
                .WithRequired(e => e.tblSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblTacGia>()
                .Property(e => e.MATG)
                .IsUnicode(false);

            modelBuilder.Entity<tblTacGia>()
                .Property(e => e.TENTG)
                .IsUnicode(false);

            modelBuilder.Entity<tblTacGia>()
                .Property(e => e.GIOITINH)
                .IsUnicode(false);

            modelBuilder.Entity<tblTacGia>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<tblTacGia>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);

            modelBuilder.Entity<tblMuon>()
                .Property(e => e.MADG)
                .IsUnicode(false);

            modelBuilder.Entity<tblMuon>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<tblMuon>()
                .Property(e => e.SOPHIEUMUON)
                .IsUnicode(false);

            modelBuilder.Entity<tblMuon>()
                .Property(e => e.XACNHANTRA)
                .IsUnicode(false);

            modelBuilder.Entity<tblMuon>()
                .Property(e => e.GHICHU)
                .IsUnicode(false);
        }
    }
}
