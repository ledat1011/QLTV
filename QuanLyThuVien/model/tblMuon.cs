namespace QuanLyThuVien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMuon")]
    public partial class tblMuon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MADG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MASACH { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SOPHIEUMUON { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime NGAYMUON { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime NGAYTRA { get; set; }

        [StringLength(50)]
        public string XACNHANTRA { get; set; }

        public string GHICHU { get; set; }

        public virtual tblDocGia tblDocGia { get; set; }

        public virtual tblSach tblSach { get; set; }
    }
}
