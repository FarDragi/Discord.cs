﻿using FarDragi.DiscordCs.Core.Gateway.Models.Base;
using FarDragi.DiscordCs.Core.Gateway.Models.Base.Guild;
using Newtonsoft.Json;

namespace FarDragi.DiscordCs.Core.Gateway.Models.Events
{
    internal sealed class EventGuildCreate : DiscordGuild
    {
        [JsonProperty("guild_hashes")]
        public DiscordGuildHashes GuildHashes { get; set; }
    }
}