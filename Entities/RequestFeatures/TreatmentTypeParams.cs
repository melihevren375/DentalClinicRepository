namespace Entities.RequestFeatures;

public class TreatmentTypeParams : RequestParams
{
    public string? NameContains { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}
