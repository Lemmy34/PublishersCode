using ADMpublishers.Core.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ADMpublishers.web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container 
            container.RegisterType<IAuthorService, AuthorService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}