using Company.Es.DAL.Models;
using Company.Es.PL.ViewModels.Auth;
using System.Net;
using System.Net.Mail;

namespace Company.Es.PL.Helper
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			// you can send email using (gmail or outlock, ...etc) -> this called Mail Server
			// Any server has Mail Server
			// I will use Mail Server for google which is (gmail.com)
			// Need this protocol: smtp

			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = true; // enable encryption

			client.Credentials = new NetworkCredential("eslamabdelwahid9@gmail.com", "oxcfawbnashqqdyv");
			// oxcfawbnashqqdyv
			client.Send("eslamabdelwahid9@gmail.com", email.To, email.Subject, email.Body);

		}
	}
}
