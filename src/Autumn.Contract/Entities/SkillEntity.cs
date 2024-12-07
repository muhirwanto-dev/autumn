namespace Autumn.Contract.Entities
{
    public class SkillEntity
    {
        public required string Name { get; set; }

        public string? Icon { get; set; }

        public string? IconUrl { get; set; }

        public double? Score { get; set; }
    }
}
