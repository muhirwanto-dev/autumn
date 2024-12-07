namespace Autumn.Contract.Entities
{
    public class ProjectEntity
    {
        public required string ProjectTitle { get; set; }

        public string? Image { get; set; }

        public string? ImageUrl { get; set; }

        public string? ProjectUrl { get; set; }

        public required string Overview { get; set; }

        public string? Description { get; set; }

        public string[] Tools { get; set; } = [];
    }
}
