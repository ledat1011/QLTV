namespace QuanLyThuVien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNXB")]
    public partial class tblNXB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblNXB()
        {
            tblSaches = new HashSet<tblSach>();
        }

        [Key]
        [StringLength(50)]
        public string MANXB { get; set; }

        [StringLength(50)]
        public string TENNXB { get; set; }

        public string DIACHI { get; set; }

        [StringLength(50)]
        public string SODIENTHOAI { get; set; }

        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSach> tblSaches { get; set; }
    }
}
