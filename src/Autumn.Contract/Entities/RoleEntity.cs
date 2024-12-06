namespace Autumn.Contract.Entities
{
    public class RoleEntity
    {
        public required string RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public string? Image { get; set; }

        public string[] TechStack { get; set; } = [];
    }
}
