namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.application")]
    public partial class application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public application()
        {
            interviews = new HashSet<interview>();
            applicationtests = new HashSet<applicationtest>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime? date_app { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        public int? folder_id { get; set; }

        public int? jobOffer_id { get; set; }

        public int? ressource_id { get; set; }

        public virtual ressource ressource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<interview> interviews { get; set; }

        public virtual joboffer joboffer { get; set; }

        public virtual folder folder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicationtest> applicationtests { get; set; }
    }
}
