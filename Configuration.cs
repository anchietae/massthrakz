namespace massthrakz
{
    public class Redirect
    {
        public List<string> Paths { get; set; }
        public string Dest { get; set; }
    }

    public class AppSettings
    {
        public required LoggingSettings Logging { get; set; }
        public required string AllowedHosts { get; set; }
        public required List<Redirect> Redirects { get; set; }
    }

    public class LoggingSettings
    {
        public LogLevelSettings LogLevel { get; set; }
    }

    public class LogLevelSettings
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }
}