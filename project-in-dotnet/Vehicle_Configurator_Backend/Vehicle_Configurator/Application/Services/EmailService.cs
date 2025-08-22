using MailKit.Net.Smtp;
using MimeKit;

public class EmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<bool> SendEmailWithAttachment(string toEmail, string subject, string body, byte[] attachmentBytes, string attachmentName)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Company", _config["EmailSettings:FromEmail"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var builder = new BodyBuilder { TextBody = body };
        builder.Attachments.Add(attachmentName, attachmentBytes);

        message.Body = builder.ToMessageBody();

        try
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_config["EmailSettings:SmtpServer"], int.Parse(_config["EmailSettings:SmtpPort"]), true);
            await client.AuthenticateAsync(_config["EmailSettings:SmtpUser"], _config["EmailSettings:SmtpPass"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            return true;
        }
        catch (Exception ex)
        {
            // log error    
            Console.WriteLine($"Email sending failed: {ex}");
            return false;
        }
    }
}
