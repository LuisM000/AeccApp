﻿#if BOT
using Microsoft.Bot.Connector;
#else
using Microsoft.Bot.Connector.DirectLine;
#endif
using Newtonsoft.Json;
using System;

namespace Aecc.Models
{
  
    public class ChannelAccountWithUserData : ChannelAccount
    {
        public ChannelAccountWithUserData()
        {

        }

        public ChannelAccountWithUserData(ChannelAccount account)
        {
#if BOT
            Properties = account.Properties;
            FirstName = Properties?[nameof(FirstName)]?.ToString();
            Surname = Properties?[nameof(Surname)]?.ToString();
            Email = Properties?[nameof(Email)]?.ToString();
            Description = Properties?[nameof(Description)]?.ToString();
            Age = Properties?[nameof(Age)]?.ToObject<int>();
            Gender = Properties?[nameof(Gender)]?.ToString();
#endif
            Id = account.Id;
            Name = account.Name;
        }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ChannelAccountWithUserData FromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<ChannelAccountWithUserData>(jsonString);
        }
    }
}