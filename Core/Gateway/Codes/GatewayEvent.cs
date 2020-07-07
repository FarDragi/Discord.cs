﻿namespace FarDragi.DragiCordApi.Core.Gateway.Codes
{
    internal enum GatewayEvent : byte
    {
        Hello,
        Ready,
        Resumed,
        Reconnect,
        InvalidSession,
        ChannelCreate,
        ChannelUpdate,
        ChannelDelete,
        ChannelPinsUpdate,
        GuildCreate,
        GuildUpdate,
        GuildDelete,
        GuildBanAdd,
        GuildBanRemove,
        GuildEmojisUpdate,
        GuildIntegrationsUpdate,
        GuildMemberAdd,
        GuildMemberRemove,
        GuildMemberUpdate,
        GuildMembersChunk,
        GuildRoleCreate,
        GuildRoleUpdate,
        GuildRoleDelete,
        InviteCreate,
        InviteDelete,
        MessageCreate,
        MessageUpdate,
        MessageDelete,
        MessageDeleteBulk,
        MessageReactionAdd,
        MessageReactionRemove,
        MessageReactionRemoveAll,
        MessageReactionRemoveEmoji,
        PresenceUpdate,
        TypingStart,
        UserUpdate,
        VoiceStateUpdate,
        VoiceServerUpdate,
        WebhooksUpdate
    }
}