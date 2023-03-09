namespace e_Tickets.Models.Mail
{
    public interface IEmailSender 
    { 

       public void SendEmail(Message message);
    }
}
