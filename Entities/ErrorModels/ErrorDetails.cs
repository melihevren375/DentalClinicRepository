using System.Text.Json;

namespace Entities.ErrorModels;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Messages { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow; 

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
