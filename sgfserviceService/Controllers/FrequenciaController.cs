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
    public class FrequenciaController : TableController<Frequencia>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Frequencia>(context, Request, Services);
        }

        // GET tables/Frequencia
        public IQueryable<Frequencia> GetAllFrequencia()
        {
            return Query(); 
        }

        // GET tables/Frequencia/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Frequencia> GetFrequencia(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Frequencia/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Frequencia> PatchFrequencia(string id, Delta<Frequencia> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Frequencia
        public async Task<IHttpActionResult> PostFrequencia(Frequencia item)
        {
            Frequencia current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Frequencia/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFrequencia(string id)
        {
             return DeleteAsync(id);
        }

    }
}