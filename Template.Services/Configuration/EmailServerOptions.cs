namespace Template.Services.Configuration
{
    public class EmailServerOptions
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string EmailUsername { get; set; }
        public string EmailPassword { get; set; }
    }
}
