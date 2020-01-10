namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.project")]
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            mandates = new HashSet<mandate>();
            ressources = new HashSet<ressource>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string adress { get; set; }

        [Column(TypeName = "bit")]
        public bool archived { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTimeKind? end_date { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int num_ressource_all { get; set; }

        public int num_ressource_levio { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTimeKind? start_date { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? client_id { get; set; }

        public virtual client client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ressource> ressources { get; set; }
    }
}
