namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.folder")]
    public partial class folder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public folder()
        {
            applications = new HashSet<application>();
            letters = new HashSet<letter>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string stateFolder { get; set; }

        [StringLength(255)]
        public string stateLetter { get; set; }

        [StringLength(255)]
        public string stateMinister { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<application> applications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<letter> letters { get; set; }
    }
}
