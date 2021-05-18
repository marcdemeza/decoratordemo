using Webservice.Models;

namespace Webservice.Services
{
    public class MainMessageService : IMessageService
    {
        public WelcomeText Get() => new("Welcome to the site!");
    }
}
