namespace Autumn.Contract.GitHub
{
    public class GithubAsset
    {
        public string? Name { get; set; }

        public string? Path { get; set; }

        public string? Sha { get; set; }

        public long Size { get; set; }

        public string? Url { get; set; }

        public string? HtmlUrl { get; set; }

        public string? GitUrl { get; set; }

        public string? DownloadUrl { get; set; }

        public string? Type { get; set; }

        public string? Content { get; set; }

        public string? Encoding { get; set; }

        public Link? Links { get; set; }

        public class Link
        {
            public string? Self { get; set; }

            public string? Git { get; set; }

            public string? Html { get; set; }
        }
    }
}
