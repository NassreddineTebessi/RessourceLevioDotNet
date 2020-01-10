using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DOMAIN;

namespace WEB.Models
{
    public class RequestModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestModel()
        {
            skills = new HashSet<SkillModel>();
            clients = new HashSet<client>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string context { get; set; }

        [Column(TypeName = "date")]
        public DateTime? deliveryDate { get; set; }

        [StringLength(255)]
        public string resourceType { get; set; }

        [Column(TypeName = "bit")]
        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillModel> skills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> clients { get; set; }
    }
}