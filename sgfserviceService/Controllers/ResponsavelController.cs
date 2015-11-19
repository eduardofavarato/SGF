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
    public class ResponsavelController : TableController<Responsavel>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Responsavel>(context, Request, Services);
        }

        // GET tables/Responsavel
        public IQueryable<Responsavel> GetAllResponsavel()
        {
            return Query(); 
        }

        // GET tables/Responsavel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Responsavel> GetResponsavel(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Responsavel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Responsavel> PatchResponsavel(string id, Delta<Responsavel> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Responsavel
        public async Task<IHttpActionResult> PostResponsavel(Responsavel item)
        {
            Responsavel current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Responsavel/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteResponsavel(string id)
        {
             return DeleteAsync(id);
        }

    }
}