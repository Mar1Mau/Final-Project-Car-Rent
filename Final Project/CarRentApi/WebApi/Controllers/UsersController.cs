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
    public class UsersController : ApiController
    {
        
        //[Authorize(Roles = "Manager, Employee")]
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<UserModel[]>(UserManager.SelectAllUsers(), new JsonMediaTypeFormatter())
            };
        }



       // [Authorize(Roles = "Manager, Employee")]
        [HttpGet]
        public HttpResponseMessage Get(string userName)
        {
            UserModel user = UserManager.SelectUserByName(userName);

            if (user != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<UserModel>(user, new JsonMediaTypeFormatter())
                };

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }


        [Route("api/Users/{name}/{password}")]
        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetByNameAndPswd(string name, string password)
        {
            UserModel user = UserManager.GetUser(name, password);

            if (user != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<UserModel>(user, new JsonMediaTypeFormatter())
                };

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }




        //[AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody]UserModel value)
        {
            bool insertResult = false;

            {
                insertResult = UserManager.InsertUser(value);
            }

            HttpStatusCode responseCode = insertResult ? HttpStatusCode.Created : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(insertResult, new JsonMediaTypeFormatter()) };
        }



        //[Authorize(Roles = "Manager, Employee, User")]
        [HttpPut]
        public HttpResponseMessage UpdateUser(string userName, [FromBody]UserModel value)
        {
            bool updateResult = false;

            if (ModelState.IsValid)
            {
                updateResult = UserManager.UpdateUserByName(userName, value);
            }

            HttpStatusCode responseCode = updateResult ? HttpStatusCode.Created : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(updateResult, new JsonMediaTypeFormatter()) };
        }


       // [Authorize(Roles = "Manager")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(string userName)
        {
            bool deleteResult = UserManager.DeleteUserByName(userName);

            HttpStatusCode responseCode = deleteResult ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(deleteResult, new JsonMediaTypeFormatter()) };
        }
    }
}
