using System;
using System.Threading.Tasks;

namespace Itmaskinen_api.Services
{
    public interface IEmailService
    {
        void SendAccountCreatedEmail(string recipient);
    }
}
