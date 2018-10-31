using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADC.Stateful.AAR.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace ADC.Stateless.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAARService _arrService;

        public ValuesController()
        {
            _arrService = ServiceProxy.Create<IAARService>(new Uri("fabric:/ADC/ADC.Stateful.AAR"), new ServicePartitionKey(0));
        }
        [HttpGet]
        public async Task<bool> Get()
        {
            return await _arrService.AppendForm("test");
        }
        
    }
}
