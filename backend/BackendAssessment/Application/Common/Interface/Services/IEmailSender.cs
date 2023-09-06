using Domain.Entities;

namespace Application.Common.Interface.Services
{
    public interface IEmailSender
    {
        public Task SendEmail(Email email);

    }
}