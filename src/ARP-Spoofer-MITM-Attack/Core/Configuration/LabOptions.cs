namespace ARPSpooferMITMAttack.Core.Configuration
{
    public class LabOptions
    {
        public int RefreshIntervalMs { get; set; } = 30000;
        public string DataEndpoint { get; set; } = "https://lab.example.com";
    }
}
