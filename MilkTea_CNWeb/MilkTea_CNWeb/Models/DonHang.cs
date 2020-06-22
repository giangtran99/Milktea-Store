namespace MilkTea_CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChitietDonHangs = new HashSet<ChitietDonHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDonHang { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public double? TongTien { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaNhanvien { get; set; }

        public int? MaGiamgia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietDonHang> ChitietDonHangs { get; set; }

        public virtual Giamgia Giamgia { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Nhanvien Nhanvien { get; set; }
    }
}
