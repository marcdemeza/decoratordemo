using Webservice.Models;

namespace Webservice.Services
{
    public class SuggestionMessageService : IMessageService
    {
        private readonly IMessageService _inner;

        public SuggestionMessageService(IMessageService messageService)
        {
            _inner = messageService;
        }

        public WelcomeText Get() => new($"{_inner.Get().Message} Would you like to read our new articles?");
    }
}
