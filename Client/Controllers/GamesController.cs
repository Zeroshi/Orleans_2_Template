//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Contracts;
//using Microsoft.AspNetCore.Mvc;
//using Orleans;

//namespace Client.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/Games")]
//    public class GamesController : Controller
//    {
//        private IClusterClient orleansClient;

//        public GamesController(IClusterClient orleansClient)
//        {
//            this.orleansClient = orleansClient;
//        }

//        [HttpGet]
//        public Task<List<string>> Get(int gameId)
//        {
//            var grain = this.orleansClient.GetGrain<IGameGrain>(gameId);
//            return grain.ListPlayersAsync();
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