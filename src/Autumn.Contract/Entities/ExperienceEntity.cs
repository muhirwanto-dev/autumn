namespace Autumn.Contract.Entities
{
    public class ExperienceEntity
    {
        public string? EndDate { get; set; }

        public string? StartDate { get; set; }

        public string? Description { get; set; }

        public required string PositionName { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanyUrl { get; set; }

        public string? CompanyImageUrl { get; set; }

        public string[] Tools { get; set; } = [];
    }
}
