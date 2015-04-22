namespace AngularWebApiApp.Domain
{
    using AngularWebApiApp.Domain.Entities;
    using AspNet.Identity.MongoDB;
    using Microsoft.AspNet.Identity;

    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(ApplicationIdentityContext identityContext)
            : base(new RoleStore<Role>(identityContext))
        {
        }
    }
}