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
    public class OrdersController : ApiController
    {

       //[Authorize(Roles = "Manager, Employee, User")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<OrderModel[]>(OrderManager.SelectAllOrders(), new JsonMediaTypeFormatter())
            };
        }

        



        //[Authorize(Roles = "Manager, Employee")]
        [HttpGet]
        public HttpResponseMessage GetByCarNumber(string carNumber)
        {
            OrderModel order = OrderManager.SelectOrderByCarNumber(carNumber);

            if (order != null)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<OrderModel>(order, new JsonMediaTypeFormatter())
                };

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }




        //[Authorize(Roles = "Manager, Employee, User")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]OrderModel value)
        {
            bool insertResult = false;
            
       
            {
                insertResult = OrderManager.InsertOrder(value);
            }

            HttpStatusCode responseCode = insertResult ? HttpStatusCode.Created : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(insertResult, new JsonMediaTypeFormatter()) };
        }



       // [Authorize(Roles = "Manager, Employee")]
        [HttpPut]
        public HttpResponseMessage Put(string carNumber, [FromBody]OrderModel value)
        {
            bool updateResult = false;
            
            {
                updateResult = OrderManager.UpdateOrderByCarNumber(carNumber, value);
            }

            HttpStatusCode responseCode = updateResult ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(updateResult, new JsonMediaTypeFormatter()) };
        }


      //  [Authorize(Roles = "Manager, Employee")]
        [HttpDelete]
        public HttpResponseMessage Delete(string carNumber)
        {
            bool deleteResult = OrderManager.DeleteOrderByDate(carNumber);

            HttpStatusCode responseCode = deleteResult ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return new HttpResponseMessage(responseCode) { Content = new ObjectContent<bool>(deleteResult, new JsonMediaTypeFormatter()) };
        }
    }
}
