using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webservice.Extensions;
using Webservice.Services;

namespace Webservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();

            services.AddScopedDecorator<IMessageService, MainMessageService>(options => options
                .DecorateWith<SuggestionMessageService>());

            services.AddScopedDecorator<IArticleService, ArticleService>(options => options
                .DecorateWith<ArticleCacheService>()
                .DecorateWith<ArticleLogService>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
