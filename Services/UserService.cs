using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerScienceTsu.Models.Generated;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace ComputerScienceTsu.Services
{
    public class UserService
    {
        private TsuModel db = new TsuModel();
        public static User SetUser(string firstname, string lastname, string username, string email, string pass)
        {
            var user = new User();
            user.Firstname = firstname;
            user.Lastname = lastname;
            user.Username = username;
            user.Email = email;
            user.Pass = pass;
            return user;
        }

        public static bool EmailExists(string email)
        {
            bool emailExists;
            using (TsuModel db = new TsuModel())
            {
                emailExists = db.Users.Any(e => e.Email == email);
            }
            return emailExists;
        }

        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                    System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }

        public static void SendEmail(string userEmail)
        {
            var from = new MailAddress("beqa77349@mail.ru", "welcome");
            var to = new MailAddress(userEmail);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, "beka12")
            };

            using (var message = new MailMessage(from, to)
            {
                Subject = "Your account successfully created!"
            })

                smtp.Send(message);
        }
        }
    }