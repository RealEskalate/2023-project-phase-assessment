using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Entities;

namespace Backend.Application.Common.Interface.Services
{
    public interface IEmailSender
    {
        public Task SendEmail(Email email);

    }
}