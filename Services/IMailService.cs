namespace Email_WebAPI.Services;

public interface IMailService
{
    public void Send(string toAddress, string subject, string body);
}