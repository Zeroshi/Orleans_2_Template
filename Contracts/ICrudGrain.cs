using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICrudGrain : IGrainWithIntegerKey
    {
        Task<bool> Insert(string item);

        Task<bool> Update(string key, string item);

        Task<bool> Delete(string item);

        Task<string> Select(string item, int resultAmount);
    }
}