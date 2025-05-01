namespace Autumn.Wasm.Models
{
    public class RoleModel
    {
        public required string RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public string? Image { get; set; }

        public string? ImageUrl { get; set; }

        public string[] Projects { get; set; } = [];
    }
}
