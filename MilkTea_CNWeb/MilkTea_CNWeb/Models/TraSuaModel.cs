namespace MilkTea_CNWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TraSuaModel : DbContext
    {
        public TraSuaModel()
            : base("name=TraSuaModel")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ChitietDonHang> ChitietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Giamgia> Giamgias { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Per_Role> Per_Role { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<tRole> tRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChitietDonHang>()
                .Property(e => e.TenSize)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Diachi)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.Diachi)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanvien>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Per_Role>()
                .Property(e => e.Per_RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Per_Role>()
                .Property(e => e.PerID)
                .IsUnicode(false);

            modelBuilder.Entity<Per_Role>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.PerID)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.PerName)
                .IsUnicode(false);
      

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Linkanh)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .Property(e => e.TenSize)
                .IsUnicode(false);

            modelBuilder.Entity<tRole>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<tRole>()
                .Property(e => e.RoleName)
                .IsUnicode(false);
        }
    }
}
