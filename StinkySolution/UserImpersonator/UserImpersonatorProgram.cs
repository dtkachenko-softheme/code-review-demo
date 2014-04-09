using System;

namespace UserImpersonator
{
    class UserImpersonatorProgram
    {
        private static UserLogger _impersonatedUserLogger;
        private static UserImpersonator _impersonator;

        static void Main(string[] args)
        {
            _impersonator = new UserImpersonator();

            var stop = false;
            while(!stop)
            {
                if (string.IsNullOrWhiteSpace(_impersonator.UserName))
                {
                    Console.Write("login:");
                    _impersonator.UserName = Console.ReadLine();
                    _impersonatedUserLogger = new UserLogger(_impersonator);
                }

                Console.Write(":");
                var command = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }

                if (command.StartsWith("logout"))
                {
                    _impersonator.UserName = string.Empty;
                }
                else if (command.StartsWith("quit") || command.StartsWith("exit"))
                {
                    stop = true;
                }
                else
                {
                    _impersonator.ExecuteCommand(command);
                }

            }
        }
    }

    

    
}
