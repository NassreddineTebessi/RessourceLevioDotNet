using DOMAIN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace WEB.Models
{
 
    public class RessourceModel
    {

        public RessourceModel()
        {
     
            skills = new HashSet<SkillModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool archived { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [StringLength(255)]
        public string token { get; set; }

        [StringLength(255)]
        public string contract_type { get; set; }

        [StringLength(255)]
        public string profile { get; set; }

        [StringLength(255)]
        public string sector { get; set; }

        [StringLength(255)]
        public string seniority { get; set; }

        [StringLength(255)]
        public string state { get; set; }
        public virtual ProjectModel project { get; set; }
        public virtual ICollection<SkillModel> skills { get; set; }




    }
}
