using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UniqueRankList.Model;

namespace UniqueRankList.Services
{
    public class LicenseEmailService
    {
        private const string SenderEmail = "gonderici@gmail.com";  // Gönderen Gmail adresi
        private const string SenderPassword = "uygulama_sifresi";  // Uygulama şifresi
        private const string RecipientEmail = "burakhanbircan15@gmail.com"; // Lisans isteklerini alacak mail

        public async Task SendLicenseRequestEmailAsync(LicenseRequestModel model)
        {
            var body = new StringBuilder();
            body.AppendLine("Yeni Lisans Talebi:");
            body.AppendLine($"Ad Soyad: {model.FullName}");
            body.AppendLine($"E-Posta: {model.Email}");
            body.AppendLine($"BIOS Serial: {model.BIOSSerial}");
            body.AppendLine($"Machine GUID: {model.MachineGuid}");
            body.AppendLine($"OS Versiyon: {model.OSVersion}");

            var message = new MailMessage(SenderEmail, RecipientEmail)
            {
                Subject = "Yeni Lisans Talebi",
                Body = body.ToString(),
                IsBodyHtml = false
            };

            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(SenderEmail, SenderPassword)
            };

            await client.SendMailAsync(message);
        }
    }
}
