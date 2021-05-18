using System;
using System.Diagnostics;
using Webservice.Models;

namespace Webservice.Services
{
    public class ArticleLogService : IArticleService
    {
        private readonly IArticleService _inner;

        public ArticleLogService(IArticleService inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public Article Get(int id)
        {
            Debug.WriteLine("Retrieving article");

            var article = _inner.Get(id);

            Debug.WriteLine("Article retrived");

            return article;
        }
    }
}
