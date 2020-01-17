﻿using System;
using Datory.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiteServer.Abstractions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LockType
    {
        [DataEnum(DisplayName = "永久锁定")]
        Forever,
        [DataEnum(DisplayName = "固定时间锁定")]
        Hours,
    }
}
