﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FarDragi.DiscordCs.Rest.Standard
{
    public class RestContext : IRestContext
    {
        private RestConfig _config;
        private HttpClient _httpClient;
        private SortedList<string, RestClient> _clients; 

        public void Init()
        {
            _httpClient = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue(_config.Type, _config.Token)
                }
            };
            _clients = new SortedList<string, RestClient>();
        }

        public IRestClient GetClient(string urlFormat, JsonSerializerOptions serializerOptions)
        {
            if (_clients.TryGetValue(urlFormat, out RestClient restClient))
            {
                return restClient;
            }
            else
            {
                RestClient client = new RestClient(_httpClient, _config.Url + urlFormat, serializerOptions);
                _clients.Add(urlFormat, client);
                return client;
            }
        }

        public void Config(IRestConfig config)
        {
            if (config is RestConfig restConfig)
            {
                _config = restConfig;
            }
        }
    }
}