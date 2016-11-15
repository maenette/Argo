﻿using Newtonsoft.Json;

namespace RedArrow.Jsorm.JsonModels
{
    internal class ErrorSource : JModel
    {
        [JsonProperty("pointer", NullValueHandling = NullValueHandling.Ignore)]
        public string Pointer { get; set; }

        [JsonProperty("parameter", NullValueHandling = NullValueHandling.Ignore)]
        public string Parameter { get; set; }
    }
}