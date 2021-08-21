using ExampleServices;
using Moq;
using NUnit.Framework;

namespace NUnitTesting
{
	[TestFixture]
	public class NotificationTests
	{
		private NotificationService _serviceToTest;
		private Mock<IEmailService> _mockEmailService;

		[SetUp]
		public void SetUp()
		{
			_serviceToTest = new NotificationService(_mockEmailService.Object);
		}

		[Test]
		public void Ensure_NotifyUser_sends_email_when_user_needs_notification()
		{
			// Arrange
			User userToAssert = null;

			_mockEmailService.Setup(x => x.SendEmail(It.IsAny<User>()))
				.Callback<User>(y => userToAssert = y);

			// Act
			var userToCheck = new User() { FirstName = "Samuel", NeedsNotification = true };
			_serviceToTest.NotifyUser(userToCheck);

			//Assert
			_mockEmailService.Verify(x=> x.SendEmail(It.IsAny<User>()), Times.Once, "A user that needs notification should be emailed");
			
			// First way of verifying the properties in the user
			_mockEmailService.Verify(x=> x.SendEmail(It.Is<User>(u => u.NeedsNotification == true && u.FirstName == "Samuel")));

			// Second way of verifying the properties in the user
			Assert.True(userToAssert.NeedsNotification);
			Assert.AreEqual("Samuel", userToAssert.FirstName);

		}
	}
}