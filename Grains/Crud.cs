using Contracts;
using Couchbase.N1QL;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core;

namespace Grains
{
    public class Crud : Grain, ICrud
    {
        private readonly IBucket _bucket;
        private readonly string _key;

        public Crud(ICouchbaseBucket bucket, string key, ILogger logger)
        {
            _bucket = bucket.GetBucket();
            _key = key;
        }

        public virtual Task<bool> Delete(string item)
        {
            var result = true;
            try
            {
                _bucket.Remove(item);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Task.FromResult<bool>(result);
        }

        public virtual Task<bool> Insert(string item)
        {
            bool result = true;
            if (!_bucket.Exists(_key))
            {
                var insert = _bucket.Insert(new Document<List<string>>
                {
                    Id = _key,
                    Content = new List<string>()
                });

                if (!insert.Success)
                {
                    if (insert.Exception != null)
                    {
                        //throw insert.Exception;
                        result = false;
                    }
                    result = false;
                    //throw new InvalidOperationException(insert.Status.ToString());
                }
            }

            return Task.FromResult<bool>(result);
        }

        public virtual Task<string> Select(string item, int resultAmount)
        {
            try
            {
                var result = _bucket.QueryAsync<string>(string.Format("SELECT TOP {0} * FROM TABLE WHERE id = {1}",
                    resultAmount, item));
                return Task.FromResult<string>(result.ToString());
            }
            catch (Exception ex)
            {
                return Task.FromResult<string>(string.Empty);
            }
        }

        public virtual Task<bool> Update(string key, string item)
        {
            var result = true;
            try
            {
                _bucket.Upsert(key, item);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Task.FromResult<bool>(result);
        }
    }
}