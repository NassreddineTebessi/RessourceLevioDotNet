using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DATA;
using MySql.Data.MySqlClient;
using WEB.Models;

namespace WEB.Controllers
{
    public class MessageController : Controller
    {
        private Context context = new Context();
        HashSet<MessageViewModel> messageView = new HashSet<MessageViewModel>();

        MySql.Data.MySqlClient.MySqlConnection dbConn =
            new MySql.Data.MySqlClient.MySqlConnection(
                "server=localhost;user id=root;password=V4Vendetta;database=leviomap");

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewMessages()
        {
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = "select m.id, m.create_date message_date, m.message, m.subject, m.type," +
                              " m.conversation conversation_id, m.from_user , m.to_user, c.create_date conversation_date, " +
                              "cl.id client_id, cl.first_name client_firstName, cl.last_name client_lastName , " +
                              "cl.email client_email,r.id resource_id, r.first_name resource_firstName, " +
                              "r.last_name resource_lastName, r.email resource_email from message m inner join conversation c " +
                              "on (m.conversation = c.id)  inner join client cl on (m.from_user = cl.id or m.to_user = cl.id) " +
                              "inner join ressource r on (r.id = m.from_user or r.id = m.to_user) where c.state = @state and (m.from_user = @id " +
                              "or m.to_user = @id ) group by m.conversation, m.subject, m.id";
            cmd.Parameters.AddWithValue("@id", 2);
            cmd.Parameters.AddWithValue("@state", "open");
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MessageViewModel message = new MessageViewModel();
                message.conversationId = Convert.ToInt32(reader.GetValue(5));
                message.converstionDate = Convert.ToDateTime(reader.GetValue(8));
                message.fromUser = Convert.ToInt32(reader.GetValue(6));
                message.toUser = Convert.ToInt32(reader.GetValue(7));
                message.messageBody = Convert.ToString(reader.GetValue(2));
                message.messageDate = Convert.ToDateTime(reader.GetValue(1));
                message.messageId = Convert.ToInt32(reader.GetValue(0));
                message.subject = Convert.ToString(reader.GetValue(3));
                message.type = Convert.ToString(reader.GetValue(4));
                message.fromFirstName = (Convert.ToInt32(reader.GetValue(6)) == Convert.ToInt32(reader.GetValue(9))
                    ? Convert.ToString(reader.GetValue(10))
                    : Convert.ToString(reader.GetValue(14)));
                message.fromLastName = (Convert.ToInt32(reader.GetValue(6)) == Convert.ToInt32(reader.GetValue(9))
                    ? Convert.ToString(reader.GetValue(11))
                    : Convert.ToString(reader.GetValue(15)));
                message.fromEmail = (Convert.ToInt32(reader.GetValue(6)) == Convert.ToInt32(reader.GetValue(9))
                    ? Convert.ToString(reader.GetValue(12))
                    : Convert.ToString(reader.GetValue(16)));
                message.toFirstName = (Convert.ToInt32(reader.GetValue(7)) == Convert.ToInt32(reader.GetValue(9))
                    ? Convert.ToString(reader.GetValue(10))
                    : Convert.ToString(reader.GetValue(14)));
                message.toLastName = (Convert.ToInt32(reader.GetValue(7)) == Convert.ToInt32(reader.GetValue(9))
                    ? Convert.ToString(reader.GetValue(11))
                    : Convert.ToString(reader.GetValue(15)));
                message.toEmail = (Convert.ToInt32(reader.GetValue(7)) == Convert.ToInt32(reader.GetValue(9))
                    ? Convert.ToString(reader.GetValue(12))
                    : Convert.ToString(reader.GetValue(16)));

                messageView.Add(message);
            }

            reader.Close();



            return View(messageView);
        }


        [HttpPost]
        public ActionResult sendMessage(int from, int to, int conversationId, String subject, String msgBody)
        {
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText =
                "INSERT into message (create_date, message, modify_date, subject, type, conversation, from_user, to_user) VALUES (NOW(), @msg, NOW(), @sub, @type, @conv, @from, @to)";
            cmd.Parameters.AddWithValue("@msg", msgBody);
            cmd.Parameters.AddWithValue("@sub", subject);
            cmd.Parameters.AddWithValue("@type", "satisfaction");
            cmd.Parameters.AddWithValue("@conv", conversationId);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);


            }
            cmd.ExecuteNonQuery();

            return RedirectToAction("ViewMessages","Message");
        }

        [HttpGet]
        public ActionResult deleteMessage(int id)
        {
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = "Delete from message where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);


            }
            cmd.ExecuteNonQuery();

            return RedirectToAction("ViewMessages", "Message");

        }

        [HttpPost]
        public ActionResult sendSmtpMessage(String from, String to, String subject, String msg)
        {
            MailMessage mail = new MailMessage();
            mail.From = new System.Net.Mail.MailAddress("mohamed@pixelwilderness.com");

            // The important part -- configuring the SMTP client
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            smtp.UseDefaultCredentials = false; // [3] Changed this
            smtp.Credentials = new NetworkCredential(mail.From.ToString(), "V4Vendetta");  // [4] Added this. Note, first parameter is NOT string.
            smtp.Host = "smtp.gmail.com";

            //recipient address
            mail.To.Add(new MailAddress(to));

            //Formatted mail body
            mail.IsBodyHtml = true;
            mail.Body = msg;
            mail.Subject = from+" : "+subject;

            smtp.Send(mail);
            return RedirectToAction("Index", "Message");
        }
    }
}