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
    public class ResponsavelAlunoController : TableController<ResponsavelAluno>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<ResponsavelAluno>(context, Request, Services);
        }

        // GET tables/ResponsavelAluno
        public IQueryable<ResponsavelAluno> GetAllResponsavelAluno()
        {
            return Query(); 
        }

        // GET tables/ResponsavelAluno/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ResponsavelAluno> GetResponsavelAluno(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ResponsavelAluno/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ResponsavelAluno> PatchResponsavelAluno(string id, Delta<ResponsavelAluno> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ResponsavelAluno
        public async Task<IHttpActionResult> PostResponsavelAluno(ResponsavelAluno item)
        {
            ResponsavelAluno current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ResponsavelAluno/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteResponsavelAluno(string id)
        {
             return DeleteAsync(id);
        }

    }
}