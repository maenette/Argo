﻿using Newtonsoft.Json.Linq;

namespace RedArrow.Argo.Client.JsonModels
{
    public static class JModelExtensions
    {
        public static JToken ToJToken(this JModel model)
        {
            return model == null
                ? JValue.CreateNull()
                : JToken.FromObject(model);
        }
    }
}
