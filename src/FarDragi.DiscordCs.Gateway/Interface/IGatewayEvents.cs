﻿using FarDragi.DiscordCs.Gateway.Models.Payload;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarDragi.DiscordCs.Gateway.Interface
{
    public interface IGatewayEvents
    {
        public event EventHandler<BasePayload<object>> Raw;
    }
}
