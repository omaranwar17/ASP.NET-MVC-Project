using System.Net;
using System.Net.Mail;

namespace App_User_10.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            if (email != null)
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("omaranw13@gmail.com", "lsqkgyoujemodann");
                client.Send("omaranw13@gmail.com" , email.To, email.Subject, email.Body);

            }

        }
    }
}
