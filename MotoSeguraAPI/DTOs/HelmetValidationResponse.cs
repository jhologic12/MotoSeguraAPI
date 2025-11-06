namespace MotoSeguraAPI.DTOs
{
    public class HelmetValidationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HelmetType { get; set; } = string.Empty;
        public bool HelmetValidated { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}