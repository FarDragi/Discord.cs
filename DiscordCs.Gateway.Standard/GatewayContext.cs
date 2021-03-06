﻿using FarDragi.DiscordCs.Caching;
using FarDragi.DiscordCs.Entity.Converters;
using FarDragi.DiscordCs.Entity.Interfaces;
using FarDragi.DiscordCs.Entity.Models.GuildModels;
using FarDragi.DiscordCs.Entity.Models.IdentifyModels;
using FarDragi.DiscordCs.Entity.Models.MessageModels;
using FarDragi.DiscordCs.Entity.Models.PayloadModels;
using FarDragi.DiscordCs.Entity.Models.ReadyModels;
using FarDragi.DiscordCs.Logging;
using FarDragi.DiscordCs.Rest;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FarDragi.DiscordCs.Gateway.Standard
{
    public class GatewayContext : IGatewayContext
    {
        private GatewayConfig _config;
        private List<IGatewayClient> _clients;
        private ILogger _logger;
        private IGatewayEvents _events;

        public async Task AddClient(Identify identify, JsonSerializerOptions serializerOptions)
        {
            IGatewayClient client = new GatewayClient(this, identify, _config, _logger, serializerOptions);
            await client.Open();
            _clients.Add(client);
        }

        public void Config(IGatewayConfig config)
        {
            if (config is GatewayConfig gatewayConfig)
            {
                _config = gatewayConfig;
            }
        }

        public void Init(int shards, IGatewayEvents events, ILogger logger)
        {
            _clients = new List<IGatewayClient>(shards);
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _events = events ?? throw new ArgumentNullException(nameof(events));
        }

        public void OnReceivedEvent(IGatewayClient gatewayClient, Payload<JsonElement> payload, string json, JsonSerializerOptions serializerOptions)
        {
            _events.OnRaw(gatewayClient, json);

            switch (payload.Event)
            {
                case "MESSAGE_CREATE":
                    _events.OnMessageCreate(gatewayClient, payload.Data.ToObject<Message>(serializerOptions));
                    break;
                case "MESSAGE_UPDATE":
                    _events.OnMessageUpdate(gatewayClient, payload.Data.ToObject<Message>(serializerOptions));
                    break;
                case "MESSAGE_DELETE":
                    _events.OnMessageDelete(gatewayClient, payload.Data.ToObject<Message>(serializerOptions));
                    break;
                case "GUILD_CREATE":
                    _events.OnGuildCreate(gatewayClient, payload.Data.ToObject<Guild>(serializerOptions));
                    break;
                case "READY":
                    _events.OnReady(gatewayClient, payload.Data.ToObject<Ready>(serializerOptions));
                    break;
                default:
                    _logger.Log(LoggingLevel.Warning, $"Event not implemented {payload.Event}");
                    break;
            }

        }
    }
}
