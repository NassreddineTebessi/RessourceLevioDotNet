namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.interview")]
    public partial class interview
    {
        public int id { get; set; }

        public DateTime? dateInterview { get; set; }

        [StringLength(255)]
        public string stateInterview { get; set; }

        [StringLength(255)]
        public string typeInterview { get; set; }

        public int? application_id { get; set; }

        public virtual application application { get; set; }
    }
}
