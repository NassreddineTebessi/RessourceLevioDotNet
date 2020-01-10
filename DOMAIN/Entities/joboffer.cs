namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.joboffer")]
    public partial class joboffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public joboffer()
        {
            applications = new HashSet<application>();
            skills = new HashSet<skill>();
        }

        public int id { get; set; }

        public DateTime? beginning { get; set; }

        public DateTime? expDate { get; set; }

        [StringLength(255)]
        public string experience { get; set; }

        [StringLength(255)]
        public string function { get; set; }

        [StringLength(255)]
        public string mission { get; set; }

        public int nbPoste { get; set; }

        [StringLength(255)]
        public string required_profile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<application> applications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skills { get; set; }
    }
}
