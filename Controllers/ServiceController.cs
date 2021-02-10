using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiEx.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            string Text = "123";
            return Text;
        }

        [HttpGet("/[controller]/api")]
        public async Task<string> api(string page,int sort)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://restfulapipython.herokuapp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =  await client.GetAsync("v1/APIs/?page="+page+"&sort="+sort);
                string resp = response.Content.ReadAsStringAsync().Result;
                return resp;
                
            }
            catch
            {
                throw;
            }
            
        }

    }
}