namespace WEB.Models
{
    using DOMAIN;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class ProjectModel
    {

        public int id { get; set; }

        [StringLength(255)]
        public string adress { get; set; }

        [Column(TypeName = "bit")]
        public bool archived { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int num_ressource_all { get; set; }

        public int num_ressource_levio { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start_date { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? client_id { get; set; }

        public virtual client client { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RessourceModel> ressources { get; set; }
    }
}
