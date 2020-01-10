using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class SkillModel
    {

        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int rating { get; set; }

        public int jobOffer_id { get; set; }

        public int request_id { get; set; }

        public int ressource_id { get; set; }

        public virtual RessourceModel ressource { get; set; }


    }
}