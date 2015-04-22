using AngularWebApiApp.Domain.Entities;
using AspNet.Identity.MongoDB;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using AngularWebApiApp.Security.Providers;
using AngularWebApiApp.Security;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using AngularWebApiApp.Data;
using AngularWebApiApp.Domain;
using AngularWebApiApp.Domain.Util;

namespace AngularWebApiApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           // BundleConfig.RegisterBundles();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var builder = new ContainerBuilder();

            builder.RegisterType<MongoContext>().AsImplementedInterfaces<MongoContext, ConcreteReflectionActivatorData>().SingleInstance();

            builder.RegisterType<AuthRepository>().SingleInstance();
            builder.RegisterType<ProjectsRepository>().SingleInstance();

            //builder.RegisterType<AuthRepository>()
            //    .WithParameters(new Parameter[]
            //    {
            //        new ResolvedParameter((info, context) => info.Name == "mongoContext",
            //            (info, context) => context.Resolve<IMongoContext>()),
            //        new ResolvedParameter((info, context) => info.Name == "userManager",
            //            (info, context) => context.Resolve<ApplicationUserManager>())
            //    }).SingleInstance();

            builder.RegisterType<AngularWebApiApp.Domain.ApplicationIdentityContext>()
                .SingleInstance();

            builder.RegisterType<UserStore<User>>()
                .AsImplementedInterfaces<IUserStore<User>, ConcreteReflectionActivatorData>()
                .SingleInstance();

            builder.RegisterType<RoleStore<Role>>()
                .AsImplementedInterfaces<IRoleStore<Role>, ConcreteReflectionActivatorData>()
                .SingleInstance();

            builder.RegisterType<ApplicationUserManager>()
                .SingleInstance();

            builder.RegisterType<ApplicationRoleManager>()
                .SingleInstance();

            builder.RegisterType<SimpleAuthorizationServerProvider>()
                .AsImplementedInterfaces<IOAuthAuthorizationServerProvider, ConcreteReflectionActivatorData>().SingleInstance();

            builder.RegisterType<SimpleRefreshTokenProvider>()
                .AsImplementedInterfaces<IAuthenticationTokenProvider, ConcreteReflectionActivatorData>().SingleInstance();

            ///*******
            ////builder.RegisterType<SimpleAuthorizationServerProvider>()
            ////    .AsImplementedInterfaces<IOAuthAuthorizationServerProvider, ConcreteReflectionActivatorData>()
            ////    .WithParameters(new Parameter[]
            ////    {
            ////        new NamedParameter("publicClientId", "self"),
            ////        new ResolvedParameter((info, context) => info.Name == "userManager",
            ////            (info, context) => context.Resolve<ApplicationUserManager>())
            ////    });

            // ********/

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            var container = builder.Build();



            var resolver = new AutofacWebApiDependencyResolver(container);           // Create an assign a dependency resolver for Web API to use.


            config.DependencyResolver = resolver;



           //// app.Use(typeof(AuthMiddleware)); This is dummy middleware no longer used.

            var fileSystem = new PhysicalFileSystem(@".\");
            var options = new FileServerOptions {
                      EnableDirectoryBrowsing = false,
                      FileSystem = fileSystem
                      };

            app.UseAutofacMiddleware(container);
            ConfigureOAuth(app, container);

            app.UseFileServer(options);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            app.UseAutofacWebApi(config);

            //InitializeData(container);

        }

        private void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = System.TimeSpan.FromMinutes(30),
                Provider = container.Resolve<IOAuthAuthorizationServerProvider>(),
                RefreshTokenProvider = container.Resolve<IAuthenticationTokenProvider>()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void InitializeData(IContainer container)
        {
            var mongoContext = container.Resolve<IMongoContext>();

            if (mongoContext.Clients.Count() == 0)
            {
                mongoContext.Clients.Insert(new Client
                {
                    Id = "ngAuthApp",
                    Secret = Helper.GetHash("abc@123"),
                    Name = "AngularJS front-end Application",
                    ApplicationType = Domain.Models.ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "http://localhost:61528",
                    //AllowedOrigin = "http://ngauthenticationweb.azurewebsites.net"
                });

                mongoContext.Clients.Insert(new Client
                {
                    Id = "consoleApp",
                    Secret = Helper.GetHash("123@abc"),
                    Name = "Console Application",
                    ApplicationType = Domain.Models.ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                });
            }
        }
    }
}