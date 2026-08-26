namespace ARPSpooferMITMAttack.Core.Models
{
    public class LabResult
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Target { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public double Score { get; set; }
        public DateTime CapturedAt { get; set; } = DateTime.UtcNow;
    }

    public class LabSnapshot
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<LabResult> Results { get; set; } = new();
        public DateTime CapturedAt { get; set; } = DateTime.UtcNow;
    }
}
