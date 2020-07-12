﻿using Newtonsoft.Json;

namespace FarDragi.DiscordCs.Core.Gateway.Models.Base
{
    internal class DiscordActivityAssets
    {
        [JsonProperty("large_image")]
        public string LargeImage { get; set; }

        [JsonProperty("large_text")]
        public string LargeText { get; set; }

        [JsonProperty("small_image")]
        public string SmallImage { get; set; }

        [JsonProperty("small_text")]
        public string SmallText { get; set; }
    }
}