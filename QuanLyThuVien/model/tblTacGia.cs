namespace QuanLyThuVien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTacGia")]
    public partial class tblTacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTacGia()
        {
            tblSaches = new HashSet<tblSach>();
        }

        [Key]
        [StringLength(50)]
        public string MATG { get; set; }

        [StringLength(50)]
        public string TENTG { get; set; }

        [StringLength(50)]
        public string GIOITINH { get; set; }

        public string DIACHI { get; set; }

        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSach> tblSaches { get; set; }
    }
}
