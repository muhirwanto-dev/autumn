namespace Autumn.Wasm.Models
{
    public class ProfileModel
    {
        public required string Name { get; set; }

        public string? Email { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Photo { get; set; }

        public string NickName { get; set; } = string.Empty;

        public string MainRole { get; set; } = string.Empty;

        public string Brief { get; set; } = string.Empty;

        public string? AboutMe { get; set; }

        public string? RandomFacts { get; set; }

        public IList<RoleModel> Roles { get; set; } = [];
    }
}
