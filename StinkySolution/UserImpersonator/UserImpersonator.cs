using System;

namespace UserImpersonator
{
    public class UserImpersonator
    {
        public string UserName { get; set; }

        public void ExecuteCommand(string command)
        {
            Console.WriteLine("run as {0}: {1}", UserName, command);

            if (CommandExecuted != null)
            {
                CommandExecuted(this, command);
            }
        }

        public event EventHandler<string> CommandExecuted;
    }
}
