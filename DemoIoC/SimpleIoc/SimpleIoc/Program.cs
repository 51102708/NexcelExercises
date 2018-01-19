namespace SimpleIoc
{
    using Microsoft.Practices.Unity;
    using SimpleIoC;
    using SimpleIoC.Implement;
    using SimpleIoC.Interface;
    using System;

    public class Program
    {
        private static void Main()
        {
            var container = new UnityContainer();
            container.RegisterType<IDatabase, Database>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IEmailSender, EmailSender>();
            container.RegisterType<Cart, Cart>();

            //DI Container sẽ tự inject Database, Logger vào Cart
            var myCart = container.Resolve<Cart>();

            myCart.Checkout(1, 1);
            Console.ReadLine();
        }
    }
}