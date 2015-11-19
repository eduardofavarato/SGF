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
    public class TurmaController : TableController<Turma>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Turma>(context, Request, Services);
        }

        // GET tables/Turma
        public IQueryable<Turma> GetAllTurma()
        {
            return Query(); 
        }

        // GET tables/Turma/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Turma> GetTurma(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Turma/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Turma> PatchTurma(string id, Delta<Turma> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Turma
        public async Task<IHttpActionResult> PostTurma(Turma item)
        {
            Turma current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Turma/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTurma(string id)
        {
             return DeleteAsync(id);
        }

    }
}