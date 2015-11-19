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
    public class NotaController : TableController<Nota>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Nota>(context, Request, Services);
        }

        // GET tables/Nota
        public IQueryable<Nota> GetAllNota()
        {
            return Query(); 
        }

        // GET tables/Nota/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Nota> GetNota(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Nota/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Nota> PatchNota(string id, Delta<Nota> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Nota
        public async Task<IHttpActionResult> PostNota(Nota item)
        {
            Nota current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Nota/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNota(string id)
        {
             return DeleteAsync(id);
        }

    }
}