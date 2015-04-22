namespace AngularWebApiApp.Data
{
    using AngularWebApiApp.Domain.Entities;
    using AngularWebApiApp.Domain.Models;
    using AngularWebApiApp.Data;
    using Microsoft.AspNet.Identity;
    using MongoDB.Driver.Builders;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AngularWebApiApp.Domain;

    public class ProjectsRepository
    {
        private readonly IMongoContext mongoContext;

        public ProjectsRepository(IMongoContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public IList<Proj> GetProjects()
        {
            List<Proj> proj = mongoContext.Projects.FindAll().ToList(); 

            return proj;
        }

    }
}
