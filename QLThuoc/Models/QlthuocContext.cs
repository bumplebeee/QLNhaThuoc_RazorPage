using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLThuoc.Models;

public partial class QlthuocContext : DbContext
{
    public QlthuocContext()
    {
    }

    public QlthuocContext(DbContextOptions<QlthuocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietPhieuDatHang> ChiTietPhieuDatHangs { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<DonViTinh> DonViTinhs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuDatHang> PhieuDatHangs { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<Thuoc> Thuocs { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<XuatXu> XuatXus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("QLThuocConnection"));
        }

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.IdHd, e.IdThuoc }).HasName("idCTHD");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.IdHd)
                .HasMaxLength(10)
                .HasColumnName("idHD");
            entity.Property(e => e.IdThuoc)
                .HasMaxLength(10)
                .HasColumnName("idThuoc");
            entity.Property(e => e.DonGia).HasColumnName("donGia");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.IdHdNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoa__idHD__5629CD9C");

            entity.HasOne(d => d.IdThuocNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdThuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__idThu__571DF1D5");
        });

        modelBuilder.Entity<ChiTietPhieuDatHang>(entity =>
        {
            entity.HasKey(e => new { e.IdPdh, e.IdThuoc }).HasName("idCTPDH");

            entity.ToTable("ChiTietPhieuDatHang");

            entity.Property(e => e.IdPdh)
                .HasMaxLength(10)
                .HasColumnName("idPDH");
            entity.Property(e => e.IdThuoc)
                .HasMaxLength(10)
                .HasColumnName("idThuoc");
            entity.Property(e => e.DonGia).HasColumnName("donGia");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.IdPdhNavigation).WithMany(p => p.ChiTietPhieuDatHangs)
                .HasForeignKey(d => d.IdPdh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__idPDH__4E88ABD4");

            entity.HasOne(d => d.IdThuocNavigation).WithMany(p => p.ChiTietPhieuDatHangs)
                .HasForeignKey(d => d.IdThuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__idThu__4F7CD00D");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.IdPn, e.IdThuoc }).HasName("idCTPN");

            entity.ToTable("ChiTietPhieuNhap");

            entity.Property(e => e.IdPn)
                .HasMaxLength(10)
                .HasColumnName("idPN");
            entity.Property(e => e.IdThuoc)
                .HasMaxLength(10)
                .HasColumnName("idThuoc");
            entity.Property(e => e.DonGia).HasColumnName("donGia");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");

            entity.HasOne(d => d.IdPnNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.IdPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhi__idPN__5FB337D6");

            entity.HasOne(d => d.IdThuocNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.IdThuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__idThu__60A75C0F");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.IdDm).HasName("PK__DanhMuc__9DB8AE544F3E9415");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.IdDm)
                .HasMaxLength(10)
                .HasColumnName("idDM");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<DonViTinh>(entity =>
        {
            entity.HasKey(e => e.IdDvt).HasName("PK__DonViTin__3E41CFD2F3552D8D");

            entity.ToTable("DonViTinh");

            entity.Property(e => e.IdDvt)
                .HasMaxLength(10)
                .HasColumnName("idDVT");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHd).HasName("PK__HoaDon__9DB889C68DBD2266");

            entity.ToTable("HoaDon");

            entity.Property(e => e.IdHd)
                .HasMaxLength(10)
                .HasColumnName("idHD");
            entity.Property(e => e.IdKh)
                .HasMaxLength(10)
                .HasColumnName("idKH");
            entity.Property(e => e.IdNv)
                .HasMaxLength(10)
                .HasColumnName("idNV");
            entity.Property(e => e.ThoiGian)
                .HasColumnType("datetime")
                .HasColumnName("thoiGian");
            entity.Property(e => e.TongTien).HasColumnName("tongTien");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__idKH__534D60F1");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__idNV__52593CB8");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKh).HasName("PK__KhachHan__9DB871741DDE14A1");

            entity.ToTable("KhachHang");

            entity.Property(e => e.IdKh)
                .HasMaxLength(10)
                .HasColumnName("idKH");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .HasColumnName("gioiTinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("hoTen");
            entity.Property(e => e.NgayThamGia).HasColumnName("ngayThamGia");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("sdt");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.IdNcc).HasName("PK__NhaCungC__3FFD068CC5FAEDBB");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.IdNcc)
                .HasMaxLength(10)
                .HasColumnName("idNCC");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("diaChi");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("sdt");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(255)
                .HasColumnName("tenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNv).HasName("PK__NhanVien__9DB8791CC712E50D");

            entity.ToTable("NhanVien");

            entity.Property(e => e.IdNv)
                .HasMaxLength(10)
                .HasColumnName("idNV");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .HasColumnName("gioiTinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("hoTen");
            entity.Property(e => e.NamSinh).HasColumnName("namSinh");
            entity.Property(e => e.NgayVaoLam).HasColumnName("ngayVaoLam");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("sdt");
        });

        modelBuilder.Entity<PhieuDatHang>(entity =>
        {
            entity.HasKey(e => e.IdPdh).HasName("PK__PhieuDat__3D05DCD72628D6B2");

            entity.ToTable("PhieuDatHang");

            entity.Property(e => e.IdPdh)
                .HasMaxLength(10)
                .HasColumnName("idPDH");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("diaChi");
            entity.Property(e => e.IdKh)
                .HasMaxLength(10)
                .HasColumnName("idKH");
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(50)
                .HasColumnName("phuongThucThanhToan");
            entity.Property(e => e.ThoiGian)
                .HasColumnType("datetime")
                .HasColumnName("thoiGian");
            entity.Property(e => e.TongTien).HasColumnName("tongTien");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trangThai");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.PhieuDatHangs)
                .HasForeignKey(d => d.IdKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuDatHa__idKH__4BAC3F29");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.IdPn).HasName("PK__PhieuNha__9DB848D60960852F");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.IdPn)
                .HasMaxLength(10)
                .HasColumnName("idPN");
            entity.Property(e => e.IdNcc)
                .HasMaxLength(10)
                .HasColumnName("idNCC");
            entity.Property(e => e.IdNv)
                .HasMaxLength(10)
                .HasColumnName("idNV");
            entity.Property(e => e.ThoiGian)
                .HasColumnType("datetime")
                .HasColumnName("thoiGian");
            entity.Property(e => e.TongTien).HasColumnName("tongTien");

            entity.HasOne(d => d.IdNccNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.IdNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhap__idNCC__5CD6CB2B");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhap__idNV__5BE2A6F2");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdTk).HasName("PK__TaiKhoan__9DB8286E39E300CF");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.IdTk)
                .HasMaxLength(10)
                .HasColumnName("idTK");
            entity.Property(e => e.IdNv)
                .HasMaxLength(10)
                .HasColumnName("idNV");
            entity.Property(e => e.IdVt)
                .HasMaxLength(10)
                .HasColumnName("idVT");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__idNV__3B75D760");

            entity.HasOne(d => d.IdVtNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdVt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__idVT__3C69FB99");
        });

        modelBuilder.Entity<Thuoc>(entity =>
        {
            entity.HasKey(e => e.IdThuoc).HasName("PK__Thuoc__301D31E604C736D0");

            entity.ToTable("Thuoc");

            entity.Property(e => e.IdThuoc)
                .HasMaxLength(10)
                .HasColumnName("idThuoc");
            entity.Property(e => e.DonGia).HasColumnName("donGia");
            entity.Property(e => e.GiaNhap).HasColumnName("giaNhap");
            entity.Property(e => e.HanSuDung).HasColumnName("hanSuDung");
            entity.Property(e => e.HinhAnh).HasColumnName("hinhAnh");
            entity.Property(e => e.IdDm)
                .HasMaxLength(10)
                .HasColumnName("idDM");
            entity.Property(e => e.IdDvt)
                .HasMaxLength(10)
                .HasColumnName("idDVT");
            entity.Property(e => e.IdXx)
                .HasMaxLength(10)
                .HasColumnName("idXX");
            entity.Property(e => e.SoLuongTon).HasColumnName("soLuongTon");
            entity.Property(e => e.TenThuoc)
                .HasMaxLength(255)
                .HasColumnName("tenThuoc");
            entity.Property(e => e.ThanhPhan)
                .HasMaxLength(255)
                .HasColumnName("thanhPhan");

            entity.HasOne(d => d.IdDmNavigation).WithMany(p => p.Thuocs)
                .HasForeignKey(d => d.IdDm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thuoc__idDM__47DBAE45");

            entity.HasOne(d => d.IdDvtNavigation).WithMany(p => p.Thuocs)
                .HasForeignKey(d => d.IdDvt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thuoc__idDVT__46E78A0C");

            entity.HasOne(d => d.IdXxNavigation).WithMany(p => p.Thuocs)
                .HasForeignKey(d => d.IdXx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thuoc__idXX__48CFD27E");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.IdVt).HasName("PK__VaiTro__9DB838207C811C57");

            entity.ToTable("VaiTro");

            entity.Property(e => e.IdVt)
                .HasMaxLength(10)
                .HasColumnName("idVT");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<XuatXu>(entity =>
        {
            entity.HasKey(e => e.IdXx).HasName("PK__XuatXu__9DB80BE64A3967C4");

            entity.ToTable("XuatXu");

            entity.Property(e => e.IdXx)
                .HasMaxLength(10)
                .HasColumnName("idXX");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
