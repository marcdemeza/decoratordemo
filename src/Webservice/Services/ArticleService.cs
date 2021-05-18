using System.Collections.Generic;
using System.Linq;
using Webservice.Models;

namespace Webservice.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IEnumerable<Article> _accounts;

        public ArticleService()
        {
            _accounts = new List<Article>
            {
                new Article { Id = 1, Title = "Everybody should try walking", Text = "Welcome to my TedTalk!"},
                new Article { Id = 2, Title = "The truth about winter", Text = "December was a cold month"},
            };
        }

        public Article Get(int id)
            => _accounts.First(a => a.Id == id);
    }
}
