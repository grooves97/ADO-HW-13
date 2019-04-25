using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCA.DataAccess;
using DCA.Models;

namespace DCA.ConsoleApp
{
    class Program
    {
        static void SendEmail()
        {
            Console.WriteLine("Кому отправить сообщение?");

            using (var receiversRepository = new ReceiverRepository())
            using (var mailsRepository = new MailsRepository())
            {
                Mail mail = new Mail();
                int ineration = 1;
                var receivers = receiversRepository.GetAll();

                foreach (var receiver in receivers)
                {
                    Console.WriteLine(ineration + ": " + receiver.FullName);
                }

                int reciverNumber;

                if (int.TryParse(Console.ReadLine(), out reciverNumber) && receivers.Count >= reciverNumber)
                {
                    mail.Receiver = receivers.ElementAt(reciverNumber - 1);
                    mail.ReceiverId = receivers.ElementAt(reciverNumber - 1).Id;
                }
                else return;

                Console.WriteLine("Введите тему сообщения");
                mail.Theme = Console.ReadLine();

                Console.WriteLine("Введите сообщениe");
                mail.Text = Console.ReadLine();

                mailsRepository.Add(mail);
            }
        }

        //static void AddReceiver()
        //{
        //    using (var reciversRepository = new ReceiverRepository())
        //    {
        //        Receiver reciver = new Receiver();
        //        Console.WriteLine("Введите имя");
        //        reciver.FullName = Console.ReadLine();
        //        Console.WriteLine("Введите адрес");
        //        reciver.Address = Console.ReadLine();

        //        reciversRepository.Add(reciver);
        //    }
        //}

        static void Main(string[] args)
        {
            SendEmail();
        }
    }
}
