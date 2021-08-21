using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExampleServices
{
	public class NotificationService
	{
		private IEmailService _emailService;

		public NotificationService(IEmailService emailService)
		{
			_emailService = emailService;
		}
		public void NotifyUser(User user)
		{
			if (user.NeedsNotification)
			{
				_emailService.SendEmail(user);
			}
		}
	}

	public interface IEmailService
	{
		void SendEmail(User user);
	}

	public class User
	{
		public string FirstName { get; set; }
		public bool NeedsNotification { get; set; }
	}
}
