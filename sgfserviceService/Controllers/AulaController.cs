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
    public class AulaController : TableController<Aula>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Aula>(context, Request, Services);
        }

        // GET tables/Aula
        public IQueryable<Aula> GetAllAula()
        {
            return Query(); 
        }

        // GET tables/Aula/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Aula> GetAula(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Aula/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Aula> PatchAula(string id, Delta<Aula> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Aula
        public async Task<IHttpActionResult> PostAula(Aula item)
        {
            Aula current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Aula/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAula(string id)
        {
             return DeleteAsync(id);
        }

    }
}