using AngularWebApiApp.Data;
using AngularWebApiApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularWebApiApp.Controllers
{
    [RoutePrefix("api/proj")]
    public class ProjController : ApiController
    {
        private readonly ProjectsRepository _projectsRepository = null;

        public ProjController(ProjectsRepository projRepo)
        {
            _projectsRepository = projRepo;
        }
        // GET api/test
        public IList<Proj> Get()
        {
            var itms = _projectsRepository.GetProjects();
            return (itms);
        }

        // GET api/test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/test
        public void Post([FromBody]string value)
        {
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
        }
    }
}
