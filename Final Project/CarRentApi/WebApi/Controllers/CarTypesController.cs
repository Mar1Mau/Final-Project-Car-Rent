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
    public class CarTypesController : ApiController
    {
        
        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<CarTypeModel[]>(CarTypeManager.SelectAllCarTypes(), new JsonMediaTypeFormatter())
            };
        }

        

      
        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetByModel(string model)
        {
            CarTypeModel carType = CarTypeManager.SelectCarTypeByModel(model);

            if (carType != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<CarTypeModel>(carType, new JsonMediaTypeFormatter())
                };

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }


       // [Authorize(Roles = "Manager")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CarTypeModel value)
        {
            bool insertResult = false;

           
            {
                insertResult = CarTypeManager.InsertCarType(value);
            }

            HttpStatusCode responseCode = insertResult ? HttpStatusCode.Created : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(insertResult, new JsonMediaTypeFormatter()) };
        }



         //[Authorize(Roles = "Manager")]
        [HttpPut]
        public HttpResponseMessage Put(string model, [FromBody]CarTypeModel value)
        {
            bool updateResult = false;

       
            {
                updateResult = CarTypeManager.UpdateCarTypeByModel(model, value);
            }

            HttpStatusCode responseCode = updateResult ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(updateResult, new JsonMediaTypeFormatter()) };
        }


        //[Authorize(Roles = "Manager")]
        [HttpDelete]
        public HttpResponseMessage Delete(string model)
        {
            bool deleteResult = CarTypeManager.DeleteCarType(model);

            HttpStatusCode responseCode = deleteResult ? HttpStatusCode.OK: HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(deleteResult, new JsonMediaTypeFormatter()) };
        }
    }
}
