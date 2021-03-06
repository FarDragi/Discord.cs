﻿using FarDragi.DiscordCs.Caching;
using FarDragi.DiscordCs.Entity.Models.MemberModels;
using FarDragi.DiscordCs.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarDragi.DiscordCs.Entity.Collections
{
    public class MemberCollection : ICacheable<ulong, Member>
    {
        private readonly ICache<ulong, Member> _cache;
        private readonly ILogger _logger;

        public MemberCollection(ICache<ulong, Member> cache, ILogger logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public Member Caching(ref Member entity, bool update = false)
        {
            _cache.Add(entity.User.Id, ref entity);
            return entity;
        }

        public async Task<Member> Find(ulong key)
        {
            if (_cache.TryGet(key, out Member member))
            {
                return member;
            }
            return null;
        }

        public IEnumerator<Member> GetEnumerator()
        {
            return _cache.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cache.GetEnumerator();
        }
    }
}
