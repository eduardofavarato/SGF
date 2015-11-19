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
    public class AdminController : TableController<Admin>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            sgfserviceContext context = new sgfserviceContext();
            DomainManager = new EntityDomainManager<Admin>(context, Request, Services);
        }

        // GET tables/Admin
        public IQueryable<Admin> GetAllAdmin()
        {
            return Query(); 
        }

        // GET tables/Admin/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Admin> GetAdmin(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Admin/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Admin> PatchAdmin(string id, Delta<Admin> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Admin
        public async Task<IHttpActionResult> PostAdmin(Admin item)
        {
            Admin current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Admin/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAdmin(string id)
        {
             return DeleteAsync(id);
        }

    }
}