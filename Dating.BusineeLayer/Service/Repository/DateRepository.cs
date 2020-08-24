using Dating.DataLayer;
using Dating.Entities;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dating.BusinessLayer.Service.Repository
{
    public class DateRepository : IDateRepository
    {
        private readonly IDateConnection _dateConnection;
        /// <summary>
        /// Inject DatingContext object
        /// </summary>
        public DateRepository(DatingContext dateContext)
        {
            _dateConnection = new DateConnection(dateContext);
        }

        /// <summary>
        /// In-Memory DB logic to send request
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>eeee
        public async Task<string> SendRequest(DateDetails user)
        {
            try
            {
                string returnResult = string.Empty;
                var dateContext = _dateConnection.GetDatingContext;
                var LstDates = dateContext.AllDates;

                var result = await LstDates.AddAsync(user);
               var sresult = await dateContext.SaveChangesAsync();
                if (sresult == 1)
                {
                    MimeMessage message = new MimeMessage();
                    MailboxAddress from = new MailboxAddress(user.RequestSenderName, user.RequestSenderEmail);
                    message.From.Add(from);

                    MailboxAddress To = new MailboxAddress(user.RequestReceiverName, user.RequestReceiverEmail);
                    message.To.Add(To);

                    message.Subject = "Dating invitation ";

                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = "<h1>Hello" + user.RequestReceiverName + "</h1>";
                    bodyBuilder.TextBody = user.RequestMessage;
                    message.Body = bodyBuilder.ToMessageBody();

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    CancellationToken token = new CancellationToken(false);
                    await client.AuthenticateAsync(user.RequestSenderEmail, "PACHAKKI",token);
           
                    client.Send(message);
                    client.Disconnect(true);
                    client.Dispose();
                    returnResult = "Invitation Send Succcessfully";
                }
                return returnResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
