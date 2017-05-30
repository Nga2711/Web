namespace OnlineShop.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sanpham_size_mausac
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sanphamma { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string sizema { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string mauma { get; set; }

        public int soluong { get; set; }

        public virtual sanpham sanpham { get; set; }
    }
}
