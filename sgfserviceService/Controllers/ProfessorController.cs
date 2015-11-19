using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using sgfserviceService.DataObjects;
using sgfserviceService.Models;

namespace sgfserviceService.Controllers
{
    public class ProfessorController : TableController<Professor>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Professor>(context, Request, Services);
        }

        // GET tables/Professor
        public IQueryable<Professor> GetAllProfessor()
        {
            return Query(); 
        }

        // GET tables/Professor/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Professor> GetProfessor(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Professor/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Professor> PatchProfessor(string id, Delta<Professor> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Professor
        public async Task<IHttpActionResult> PostProfessor(Professor item)
        {
            Professor current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Professor/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteProfessor(string id)
        {
             return DeleteAsync(id);
        }

    }
}