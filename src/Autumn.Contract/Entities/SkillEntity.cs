namespace Autumn.Contract.Entities
{
    public class SkillEntity
    {
        public required string Name { get; set; }

        public string? IconPath { get; set; }

        public int Score { get; set; }
    }
}
