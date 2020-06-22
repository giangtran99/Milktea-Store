namespace MilkTea_CNWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Per_Role
    {
        [StringLength(100)]
        public string Per_RoleID { get; set; }

        [StringLength(100)]
        public string PerID { get; set; }

        [StringLength(100)]
        public string RoleID { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual tRole tRole { get; set; }
    }
}
