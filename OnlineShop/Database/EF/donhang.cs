namespace OnlineShop.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("donhang")]
    public partial class donhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donhang()
        {
            chitietdonhangs = new HashSet<chitietdonhang>();
        }

        [Key]
        public int ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaylap { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaygiao { get; set; }

        [Required]
        [StringLength(150)]
        public string diadiemgiao { get; set; }

        [Column(TypeName = "money")]
        public decimal phivanchuyen { get; set; }

        [Column(TypeName = "money")]
        public decimal tonggia { get; set; }

        public int khachhangma { get; set; }

        public long trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdonhang> chitietdonhangs { get; set; }

        public virtual khachhang khachhang { get; set; }
    }
}
