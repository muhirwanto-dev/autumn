namespace Autumn.Wasm.Models
{
    public class ExperienceModel
    {
        public required string CompanyName { get; set; }

        public string? CompanyUrl { get; set; }

        public required string JobPosition { get; set; }

        public string? JobDescription { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public string[] Tech { get; set; } = [];
    }
}
