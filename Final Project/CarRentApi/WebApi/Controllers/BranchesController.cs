using BLL;
using BOL;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    //[BasicAuthFilter]
    public class BranchesController : ApiController
    {

        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<BranchModel[]>(BranchManager.SelectAllBranches(), new JsonMediaTypeFormatter())
            };
        }



        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get(string branchName)
        {
            BranchModel branch = BranchManager.SelectBranchByName(branchName);

            if (branch != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<BranchModel>(branch, new JsonMediaTypeFormatter())
                };

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        
    }
}
