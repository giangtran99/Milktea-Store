namespace MilkTea_CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChitietDonHang")]
    public partial class ChitietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChitietDonHang { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaTopping { get; set; }

        public int? MaDonHang { get; set; }

        [StringLength(50)]
        public string TenSize { get; set; }

        public int? SoLuong { get; set; }

        public double? Thanhtien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual Topping Topping { get; set; }

        public virtual Size Size { get; set; }
    }
}
