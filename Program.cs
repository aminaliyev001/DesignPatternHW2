namespace SingleResponsibilityPrincipleBefore
{
    public class User
    {
        public string Email { get; set; }
    }
    public class UserSettings
    {
        public User User { get; set; }
        public void Emailideyis(string newEmail)
        {
            if (VerifyEmail(newEmail))
            {
                User.Email = newEmail;
            }
        }
        private bool VerifyEmail(string email)
        {
            // nese algorithm
            return true;
        }
    }
}
namespace SingleResponsibilityPrincipleAfter
{
    class User
    {
        public string Email { get; set; }
    }

    class EmailService
    {
        public bool VerifyEmail(string email)
        {
            return true;
        }
    }
    class UserSettings
    {
        private EmailService emailService;
        public User User { get; set; }

        public UserSettings(EmailService service)
        {
            emailService = service;
        }

        public void emaildeyis(string newEmail)
        {
            if (emailService.VerifyEmail(newEmail))
            {
                User.Email = newEmail;
            }
        }
    }
}
namespace OpenClosedPrincipleBefore
{
    public class EndirimCalculator
    {
        public double DiscountHesabla(double price, string type)
        {
            if (type == "nese")
            {
                return price * 0.5;
            }
            return price;
        }
    }

}
namespace OpenClosedPrincipleAfter
{
    public interface IEndirimCalculator
    {
        double CalculateDiscount(double price);
    }
    public class IsEndirimCalculator : IEndirimCalculator
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.5;
        }
    }
    public class neseEndirimCalculator : IEndirimCalculator
    {
        public double CalculateDiscount(double price)
        {
            return price;
        }
    }
}
namespace LiskovSubstitutionPrincipleBefore
{
    public class Bird
    {
        public virtual void Fly()
        {
        }
    }

    public class Toyug : Bird
    {
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }

}
namespace LiskovSubstitutionPrincipleAfter
{
    public abstract class Bird
    {
    }
    public abstract class UcanBird : Bird
    {
        public abstract void Fly();
    }
    public class Qarga : UcanBird
    {
        public override void Fly()
        {
        }
    }
    public class Toyug : Bird
    {
        public void gezmek()
        {
            Console.WriteLine("Uca bilmirem");
        }
    }

}
namespace InterfaceSegregationPrincipleBefore
{
    public interface IWorker
        {
            public void Work();
            public void HesabatEle();
        }

    public class Worker : IWorker
    {
        public void Work()
        {
        }
        public void HesabatEle()
        {
        }
    }

}
namespace InterfaceSegregationPrincipleAfter
{
    public interface IWorker
    {
        void Work();
    }
    public interface IHesabatEden
    {
        void calculate();
    }
    public class Worker : IWorker, IHesabatEden
    {
        public void Work()
        {
        }
        public void calculate()
        {
        }
    }

}
namespace DependencyInversionPrincipleBefore
{
    public class EmailService
    {
        public void SendEmail()
        {
        }
    }
    public class Notification
    {
        private EmailService emailService = new EmailService();
        public void sendBildiris ()
        {
            emailService.SendEmail();
        }
    }

}
namespace DependencyInversionPrincipleAfter
{
    public interface IMessageService
    {
        public void SendMessage();
    }
    public class EmailService : IMessageService
    {
        public void SendMessage()
        {
        }
    }

    public class Notification
    {
        private IMessageService messageService;

        public Notification(IMessageService service)
        {
            messageService = service;
        }
        public void sendBildiris()
        {
            messageService.SendMessage();
        }
    }

}