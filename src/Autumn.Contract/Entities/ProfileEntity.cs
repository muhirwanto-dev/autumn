namespace Autumn.Contract.Entities
{
    public class ProfileEntity
    {
        public string? AboutMe { get; set; }

        public required string FullName { get; set; }

        public required string FirstName { get; set; }

        public string? NickName { get; set; }

        public string? TagLine { get; set; }

        public RoleEntity[]? Roles { get; set; }
    }
}
