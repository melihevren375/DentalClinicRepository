namespace Entities.RequestFeatures;

public class AppointmentParams:RequestParams
{
    public DateTime? MaxDate { get; set; }
    public DateTime? MinDate { get; set; }
    public bool? IsActive { get; set; }
    public string? Notes { get; set; }
}
