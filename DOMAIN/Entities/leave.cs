namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.leave")]
    public partial class leave
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start_date { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? ressource_id { get; set; }

        public virtual ressource ressource { get; set; }
    }
}
