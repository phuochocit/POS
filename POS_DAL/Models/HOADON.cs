namespace POS_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHD = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(11)]
        public string MAHD { get; set; }

        [StringLength(255)]
        public string TENKH { get; set; }

        public int? SL { get; set; }

        public DateTime? THOIGIAN { get; set; }

        [StringLength(50)]
        public string HINHTHUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHD { get; set; }
    }
}
