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
    public class AlunoController : TableController<Aluno>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Aluno>(context, Request, Services);
        }

        // GET tables/Aluno
        public IQueryable<Aluno> GetAllAluno()
        {
            return Query(); 
        }

        // GET tables/Aluno/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Aluno> GetAluno(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Aluno/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Aluno> PatchAluno(string id, Delta<Aluno> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Aluno
        public async Task<IHttpActionResult> PostAluno(Aluno item)
        {
            Aluno current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Aluno/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAluno(string id)
        {
             return DeleteAsync(id);
        }

    }
}