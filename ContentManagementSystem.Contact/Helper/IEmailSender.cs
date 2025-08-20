using ContentManagementSystem.Shared;

namespace ContentManagementSystem.Contact.Helper
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string userEmail, string subject, string body, bool isHtml = false);
    }
}
