namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.skill")]
    public partial class skill
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? rating { get; set; }

        public int? jobOffer_id { get; set; }

        public int? request_id { get; set; }

        public int? ressource_id { get; set; }

        public virtual joboffer joboffer { get; set; }

        public virtual request request { get; set; }

        public virtual ressource ressource { get; set; }
    }
}
