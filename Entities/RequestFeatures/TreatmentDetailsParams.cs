namespace Entities.RequestFeatures
{
    public class TreatmentDetailsParams:RequestParams
    {
        public int? MinToothNumber { get; set; } 
        public int? MaxToothNumber { get; set; } 
        public Guid? TreatmentTypeId { get; set; } 
        public bool? IsCompleted { get; set; } 
        public Guid? TreatmentId { get; set; }
        public string? NotesContains { get; set; } 
    }
}
