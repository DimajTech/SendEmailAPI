

using SendEmailAPI.Model;

namespace SendEmailAPI.Service
{
    public interface IEmailService
    {
        void SendEmail(Email request);
    }
}
