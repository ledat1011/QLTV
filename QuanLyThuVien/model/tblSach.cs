namespace QuanLyThuVien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSach")]
    public partial class tblSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSach()
        {
            tblMuons = new HashSet<tblMuon>();
        }

        [Key]
        [StringLength(50)]
        public string MASACH { get; set; }

        [StringLength(50)]
        public string TENSACH { get; set; }

        [StringLength(50)]
        public string MATG { get; set; }

        [StringLength(50)]
        public string MANXB { get; set; }

        [StringLength(50)]
        public string MaLv { get; set; }

        [StringLength(50)]
        public string NAMXB { get; set; }

        public int? SOTRANG { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(50)]
        public string NGAYNHAP { get; set; }

        public string GHICHU { get; set; }

        public int? SOSACHHONG { get; set; }

        public virtual tblLinhVuc tblLinhVuc { get; set; }

        public virtual tblNXB tblNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMuon> tblMuons { get; set; }

        public virtual tblTacGia tblTacGia { get; set; }
    }
}
