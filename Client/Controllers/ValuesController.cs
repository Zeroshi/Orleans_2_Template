using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IClusterClient _orleansClient;

        public ValuesController(IClusterClient orleansClient)
        {
            this._orleansClient = orleansClient;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public async Task<string> Get(string item, int resultAmount)
        {
            var response = string.Empty;
            var grain = _orleansClient.GetGrain<ICrudGrain>(0);
            response = await grain.Select(item, resultAmount);
            return response;
        }

        [HttpPut]
        public async Task Insert(string item)
        {
            var grain = this._orleansClient.GetGrain<ICrudGrain>(0);
            await grain.Insert(item);
        }

        [HttpPut]
        public async Task Update(string key, string item)
        {
            var grain = this._orleansClient.GetGrain<ICrudGrain>(0);
            await grain.Update(key, item);
        }

        [HttpDelete]
        public async Task Delete(string item)
        {
            var grain = this._orleansClient.GetGrain<ICrudGrain>(0);
            await grain.Delete(item);
        }
    }
}