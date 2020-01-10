using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace WEB.Models
{
    public class ConversationModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConversationModel()
        {
            messages = new HashSet<MessageModel>();
        }

        public int id { get; set; }

        public DateTime? create_date { get; set; }

        public DateTime? modify_date { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageModel> messages { get; set; }
    }
}