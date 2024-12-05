namespace Autumn.Contract.Entities
{
    public class ProfileEntity
    {
        public string? AboutMe { get; set; }

        public required string FullName { get; set; }

        public required string FirstName { get; set; }

        public required string Role { get; set; }

        public string? RoleDescription { get; set; }

        public IEnumerable<SkillEntity> SkillSet { get; set; } = [];
    }
}
