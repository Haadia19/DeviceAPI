using DeviceAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DeviceRepoistory deviceRepoistory;
        public ValuesController()
        {
            deviceRepoistory = new DeviceRepoistory();
        }

        [HttpGet]
        public IEnumerable<Device> Get()
        {
            return deviceRepoistory.Get();
        }

        [HttpPost]
        public void Post([FromBody] Device dev)
        {
            if (ModelState.IsValid)
            {
                dev.Devid = Guid.NewGuid();
                deviceRepoistory.Add(dev);
            }
        }


    }
}
