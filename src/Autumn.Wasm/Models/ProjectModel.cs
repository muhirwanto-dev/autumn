namespace Autumn.Wasm.Models
{
    public class ProjectModel
    {
        public required string ProjectId { get; set; }

        public required string Title { get; set; }

        public string? Image { get; set; }

        public string? ProjectUrl { get; set; }

        public required string Overview { get; set; }

        public string? Description { get; set; }

        public string[] Tech { get; set; } = [];

        public bool IsOverlayVisible { get; set; } = false;
    }
}
