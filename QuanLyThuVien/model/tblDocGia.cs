namespace QuanLyThuVien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDocGia")]
    public partial class tblDocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDocGia()
        {
            tblMuons = new HashSet<tblMuon>();
        }

        [Key]
        [StringLength(50)]
        public string MADG { get; set; }

        [StringLength(50)]
        public string HOTEN { get; set; }

        [StringLength(50)]
        public string NGAYSINH { get; set; }

        [StringLength(50)]
        public string GIOITINH { get; set; }

        [StringLength(50)]
        public string LOP { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMuon> tblMuons { get; set; }
    }
}
