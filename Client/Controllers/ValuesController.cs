//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Contracts;
//using Microsoft.AspNetCore.Mvc;
//using Orleans;

//namespace Client.Controllers
//{
//    [Route("api/[controller]")]
//    public class ValuesController : Controller
//    {
//        private IClusterClient orleansClient;

//        public ValuesController(IClusterClient orleansClient)
//        {
//            this.orleansClient = orleansClient;
//        }

//        // GET api/values
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        [HttpGet]
//        public Task<List<string>> Get(int gameId)
//        {
//            var grain = this.orleansClient.GetGrain<ICrud>(gameId);
//            return grain.SelectListAsync(gameid);
//        }

//        [HttpPut]
//        public async Task Put(int gameId, string playerName)
//        {
//            var grain = this.orleansClient.GetGrain<IGameGrain>(gameId);
//            await grain.JoinAsync(playerName);
//        }

//        [HttpDelete]
//        public async Task Delete(int gameId, string playerName)
//        {
//            var grain = this.orleansClient.GetGrain<IGameGrain>(gameId);
//            await grain.LeaveAsync(playerName);
//        }
//    }
//}