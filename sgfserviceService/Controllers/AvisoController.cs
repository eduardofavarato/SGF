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
    public class AvisoController : TableController<Aviso>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Aviso>(context, Request, Services);
        }

        // GET tables/Aviso
        public IQueryable<Aviso> GetAllAviso()
        {
            return Query(); 
        }

        // GET tables/Aviso/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Aviso> GetAviso(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Aviso/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Aviso> PatchAviso(string id, Delta<Aviso> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Aviso
        public async Task<IHttpActionResult> PostAviso(Aviso item)
        {
            Aviso current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Aviso/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAviso(string id)
        {
             return DeleteAsync(id);
        }

    }
}