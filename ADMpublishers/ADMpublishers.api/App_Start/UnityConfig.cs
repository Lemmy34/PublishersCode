using ADMpublishers.Data.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ADMpublishers.api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all 
            container.RegisterType<IAuthorRepository, AuthorRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}