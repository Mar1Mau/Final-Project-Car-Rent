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
    public class CarsController : ApiController
    {

        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<CarModel[]>(CarManager.SelectAllCars(), new JsonMediaTypeFormatter())
            };
        }



        //[AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Get(string carNumber)
        {
            CarModel car = CarManager.SelectCarByCarNumber(carNumber);

            if (car != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<CarModel>(car, new JsonMediaTypeFormatter())
                };

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        

        //[Authorize(Roles = "Manager")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]CarModel value)
        {
            bool insertResult = false;

       
            {
                insertResult = CarManager.InsertCar(value);
            }

            HttpStatusCode responseCode = insertResult ? HttpStatusCode.Created : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(insertResult, new JsonMediaTypeFormatter()) };
        }



         //[Authorize(Roles = "Manager")]
        [HttpPut]
        public HttpResponseMessage Put(string carNumber, [FromBody]CarModel value)
        {
            bool updateResult = false;

           
            {
                updateResult = CarManager.UpdateCarByCarNumber(carNumber, value);
            }

            HttpStatusCode responseCode = updateResult ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(updateResult, new JsonMediaTypeFormatter()) };
        }


        //[Authorize(Roles = "Manager")]
        [HttpDelete]
        public HttpResponseMessage Delete(string carNumber)
        {
            bool deleteResult = CarManager.DeleteCarByCarNumber(carNumber);

            HttpStatusCode responseCode = deleteResult ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(deleteResult, new JsonMediaTypeFormatter()) };
        }
    }
}
