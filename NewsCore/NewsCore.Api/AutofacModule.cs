using Autofac;
using Autofac.Core;
using NewsCore.Api.Services;
using NewsCore.Data;
using NewsCore.Domain.Interfaces;

namespace NewsCore.Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Api.Services.NewsService>().As<Api.Interfaces.INewsService>();
            builder.RegisterType<NewsRepository>().As<Domain.Interfaces.INewsRepository>();
            builder.RegisterType<Domain.Services.NewsService>().As<Domain.Interfaces.INewsService>();
        }
    }
}