namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.letter")]
    public partial class letter
    {
        public int id { get; set; }

        [StringLength(255)]
        public string contratType { get; set; }

        public float salary { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? folder_id { get; set; }

        public virtual folder folder { get; set; }
    }
}
