using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace DTO
{
    public class SendMail
    {
        public static bool sendMail(string from, string to, string content, string pass)
        {
            
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from);
                mail.Subject = "Phiếu Thanh Toán Hóa Đơn Cửa Hàng Thú Cưng";
                mail.Body = content;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Lỗi trong quá trình send mail " + ex);
            }
        }
    }
}
