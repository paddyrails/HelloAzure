using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HelloAzure.BusinessLogic;

namespace HelloAzure.Functions
{
    public static class SayHello
    {
        [FunctionName("SayHello")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            GreetingService greetingService = new GreetingService();
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            if(name != null){
                string greeting = greetingService.GetGreeting(name);
                return (ActionResult)new OkObjectResult(greeting);
            }

            return new BadRequestObjectResult("Please pass a name on the query string or in request body");
        }
    }
}
