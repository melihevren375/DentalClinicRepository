﻿using System.Text.Json;

namespace Entities.LogModels;

public class LogDetails
{
    public Object? Controller { get; set; }
    public Object? ModelName { get; set; }
    public Object? Action { get; set; }
    public Object? CreateAt { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
