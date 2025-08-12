namespace LlavesquiPoems.Application.Configurations;

public class SmtpConfiguration
{
    public string UserName { get; set; }
    public string UserKey { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnabledSsl { get; set; }
}