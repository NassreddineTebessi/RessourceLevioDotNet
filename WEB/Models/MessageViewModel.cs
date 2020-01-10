using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class MessageViewModel
    {
        public int messageId { get; set; }
        public int conversationId { get; set; }
        public DateTime messageDate { get; set; }
        public DateTime converstionDate { get; set; }
        public String subject { get; set; }
        public String type { get; set; }
        public int fromUser { get; set; }
        public int toUser { get; set; }
        public String messageBody { get; set; }
        public String toFirstName { get; set; }
        public String toLastName { get; set; }
        public String toEmail { get; set; }
        public String fromFirstName { get; set; }
        public String fromLastName { get; set; }
        public String fromEmail { get; set; }

    }
}