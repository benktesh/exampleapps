using System;
using System.Web.Http;
using MyGateway.Models;

namespace MyGateway.Controllers
{
    public class GatewayController : ApiController
    {
        public string GetResults(RequestData requestData)
        {
            DateTime requestDateTime = DateTime.Now;
            var manager = new Manager();
            string jsonData = manager.GetResultList(requestData, requestDateTime);
            return jsonData;
        }
    }
}
