namespace POS_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTHD = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(6)]
        public string MASP { get; set; }

        [StringLength(255)]
        public string TENSP { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIATIEN { get; set; }

        public int? SL { get; set; }

        [Required]
        [StringLength(255)]
        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHD { get; set; }
    }
}
