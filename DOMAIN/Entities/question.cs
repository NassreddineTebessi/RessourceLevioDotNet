namespace DOMAIN
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("levio_map.question")]
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            tests = new HashSet<test>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        [StringLength(255)]
        public string choice1 { get; set; }

        [StringLength(255)]
        public string choice2 { get; set; }

        [StringLength(255)]
        public string choice3 { get; set; }

        [StringLength(255)]
        public string choice4 { get; set; }

        [StringLength(255)]
        public string validChoise { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> tests { get; set; }
    }
}
