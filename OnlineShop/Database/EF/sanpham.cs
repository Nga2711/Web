namespace OnlineShop.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanpham()
        {
            chitietdonhangs = new HashSet<chitietdonhang>();
            sanpham_size_mausac = new HashSet<sanpham_size_mausac>();
        }

        [Key]
        public int ma { get; set; }

        [Required]
        [StringLength(50)]
        public string ten { get; set; }

        [Column(TypeName = "money")]
        public decimal gia { get; set; }

        [Column(TypeName = "ntext")]
        public string mota { get; set; }

        [StringLength(50)]
        public string nhasanxuat { get; set; }

        [StringLength(50)]
        public string anh { get; set; }

        public int? loaisanphamma { get; set; }

        public int? danhmucma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdonhang> chitietdonhangs { get; set; }

        public virtual danhmuc danhmuc { get; set; }

        public virtual loaisanpham loaisanpham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham_size_mausac> sanpham_size_mausac { get; set; }
    }
}
