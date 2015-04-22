namespace AngularWebApiApp.Domain
{
    using AngularWebApiApp.Domain.Entities;
    using AspNet.Identity.MongoDB;
    using Microsoft.AspNet.Identity;

    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(ApplicationIdentityContext identityContext)
            : base(new UserStore<User>(identityContext))
        {
        }
    }
}