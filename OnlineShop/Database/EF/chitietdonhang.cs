namespace OnlineShop.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietdonhang")]
    public partial class chitietdonhang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int hoadonma { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sanphamma { get; set; }

        public int soluong { get; set; }

        [Column(TypeName = "money")]
        public decimal thanhtien { get; set; }

        public virtual donhang donhang { get; set; }

        public virtual sanpham sanpham { get; set; }
    }
}
