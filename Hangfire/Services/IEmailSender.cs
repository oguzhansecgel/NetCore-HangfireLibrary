namespace Hangfire.Services
{
    public interface IEmailSender
    {
        Task Sender(string userID, string message);
    }
}
