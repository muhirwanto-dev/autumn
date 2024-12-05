﻿namespace Autumn.Contract.Entities
{
    internal class ProjectEntity
    {
        public required string ProjectTitle { get; set; }

        public string? Image { get; set; }

        public string? ProjectUrl { get; set; }

        public required string Overview { get; set; }

        public string? Description { get; set; }

        public string[] Tools { get; set; } = [];
    }
}