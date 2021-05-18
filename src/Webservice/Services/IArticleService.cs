using Webservice.Models;

namespace Webservice.Services
{
    public interface IArticleService
    {
        Article Get(int id);
    }
}