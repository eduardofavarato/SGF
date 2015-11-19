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
    public class TurmaDisciplinaController : TableController<TurmaDisciplina>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<TurmaDisciplina>(context, Request, Services);
        }

        // GET tables/TurmaDisciplina
        public IQueryable<TurmaDisciplina> GetAllTurmaDisciplina()
        {
            return Query(); 
        }

        // GET tables/TurmaDisciplina/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TurmaDisciplina> GetTurmaDisciplina(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TurmaDisciplina/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TurmaDisciplina> PatchTurmaDisciplina(string id, Delta<TurmaDisciplina> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TurmaDisciplina
        public async Task<IHttpActionResult> PostTurmaDisciplina(TurmaDisciplina item)
        {
            TurmaDisciplina current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TurmaDisciplina/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTurmaDisciplina(string id)
        {
             return DeleteAsync(id);
        }

    }
}