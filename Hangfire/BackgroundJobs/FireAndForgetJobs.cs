using Hangfire.Services;

namespace Hangfire.BackgroundJobs
{
    public class FireAndForgetJobs
    {


        public static void EmailSendToUserJob(string userID,string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x=>x.Sender(userID,message));

        
        }





    }
}
