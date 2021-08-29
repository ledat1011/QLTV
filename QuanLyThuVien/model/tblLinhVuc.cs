namespace QuanLyThuVien.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLinhVuc")]
    public partial class tblLinhVuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLinhVuc()
        {
            tblSaches = new HashSet<tblSach>();
        }

        [Key]
        [StringLength(50)]
        public string MaLv { get; set; }

        [StringLength(50)]
        public string TenLv { get; set; }

        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSach> tblSaches { get; set; }
    }
}
