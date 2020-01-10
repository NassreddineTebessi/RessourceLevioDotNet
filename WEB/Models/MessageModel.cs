using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class MessageModel
    {

        public int id { get; set; }

        public DateTime? create_date { get; set; }

        [Column("message")]
        [StringLength(255)]
        public string message1 { get; set; }

        public DateTime? modify_date { get; set; }

        [StringLength(255)]
        public string subject { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? conversation { get; set; }

        public int? from_user { get; set; }

        public int? to_user { get; set; }

        public virtual ConversationModel conversation1 { get; set; }
    }
}