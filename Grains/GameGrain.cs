using Contracts;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grains
{
    //public class GameGrain : Grain, IGameGrain
    //{
    //    private HashSet<string> players;

    //    public GameGrain(ILogger logger) => this.players = new HashSet<string>();

    //    public Task JoinAsync(string playerName)
    //    {
    //        this.players.Add(playerName);
    //        return Task.CompletedTask;
    //    }

    //    public Task LeaveAsync(string playerName)
    //    {
    //        this.players.Remove(playerName);
    //        return Task.CompletedTask;
    //    }

    //    public Task<List<string>> ListPlayersAsync()
    //        => Task.FromResult(this.players.ToList());
    //}
}