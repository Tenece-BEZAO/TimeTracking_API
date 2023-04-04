﻿using System.Text.Json;

namespace Time_Tracking.Shared.Error
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);

    }
}
