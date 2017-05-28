namespace OnlineShop.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [Key]
        [StringLength(50)]
        public string tentruycap { get; set; }

        [Required]
        [StringLength(20)]
        public string matkhau { get; set; }

        [StringLength(50)]
        public string bidanh { get; set; }
    }
}
