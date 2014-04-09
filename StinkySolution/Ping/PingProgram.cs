using System;
using System.Net.Mail;

namespace Ping
{
    class PingProgram
    {
        static void Main(string[] args)
        {
            if (!AreValid(args))
            {
                return;
            }

            var commandArguments = Parse(args);

            var message = new MailMessage();
            message.To.Add(commandArguments.Email);
            message.Subject = "Ping";

            var from = new MailAddress("negligent.developer@gmail.com");

            message.From = from;
            message.Body = "This is ping message";

            Send(message, commandArguments.RepeatTimes);
        }

        private static bool AreValid(string[] args)
        {
            const string usageHelp = "usage: Ping [email] [times]";

            if (args == null)
            {
                Console.WriteLine(usageHelp);
                return false;
            }

            if (args.Length != 2)
            {
                Console.WriteLine(usageHelp);
                return false;
            }

            return true;
        }

        private static CommandlineArgumetns Parse(string[] args)
        {
            var messageArguments = new CommandlineArgumetns
            {
                Email = args[0],
                RepeatTimes = int.Parse(args[1])
            };

            return messageArguments;
        }

        private static void Send(MailMessage message, int repeatTimes)
        {
            var smtp = new SmtpClient("smtp.gmail.com");

            for (var i = 0; i < repeatTimes; i++)
            {
                smtp.Send(message);
            }
        }

        private class CommandlineArgumetns
        {
            public string Email { get; set; }
            public int RepeatTimes { get; set; }
        }
    }
}
