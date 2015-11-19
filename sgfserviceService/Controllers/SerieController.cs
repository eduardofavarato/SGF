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
    public class SerieController : TableController<Serie>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Serie>(context, Request, Services);
        }

        // GET tables/Serie
        public IQueryable<Serie> GetAllSerie()
        {
            return Query(); 
        }

        // GET tables/Serie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Serie> GetSerie(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Serie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Serie> PatchSerie(string id, Delta<Serie> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Serie
        public async Task<IHttpActionResult> PostSerie(Serie item)
        {
            Serie current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Serie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSerie(string id)
        {
             return DeleteAsync(id);
        }

    }
}