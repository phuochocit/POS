namespace POS_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string MAHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MASP { get; set; }

        //[StringLength(255)]
        //public string TENSP { get; set; }

        [Column(TypeName = "money")]
        //public decimal GIATIEN { get; set; }
        //public int SL { get; set; }
        public int? SL { get; set; }
        public decimal? GIATIEN { get; set; }

        [Required]
        [StringLength(50)]
        public string HINHTHUC { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
