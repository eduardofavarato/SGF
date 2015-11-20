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
    public class UsuarioController : TableController<Usuario>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Usuario>(context, Request, Services);
        }

        // GET tables/Usuario
        public IQueryable<Usuario> GetAllUsuario()
        {
            return Query(); 
        }

        // GET tables/Usuario/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Usuario> GetUsuario(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Usuario/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Usuario> PatchUsuario(string id, Delta<Usuario> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Usuario
        public async Task<IHttpActionResult> PostUsuario(Usuario item)
        {
            Usuario current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Usuario/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUsuario(string id)
        {
             return DeleteAsync(id);
        }

    }
}