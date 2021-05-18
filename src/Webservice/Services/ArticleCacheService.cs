using Microsoft.Extensions.Caching.Memory;
using System;
using Webservice.Models;

namespace Webservice.Services
{
    public class ArticleCacheService : IArticleService
    {
        private readonly IMemoryCache _cache;
        private readonly IArticleService _inner;

        public ArticleCacheService(IMemoryCache cache, IArticleService articleService)
        {
            _cache = cache;
            _inner = articleService;
        }

        public Article Get(int id)
        {
            if (_cache.TryGetValue(id, out var article))
            {
                return (Article)article;
            }

            var realArticle = _inner.Get(id);

            _cache.Set(id, realArticle, TimeSpan.FromMinutes(10));

            return realArticle;
        }
    }
}
