using System;
using System.IO;

namespace UserImpersonator
{
    public class UserLogger : IDisposable
    {
        private readonly StreamWriter _logWriter;

        public UserLogger(UserImpersonator impersonatedUser)
        {
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }

            _logWriter = new StreamWriter(File.OpenWrite(String.Format(@".\Logs\{0}.txt", impersonatedUser.UserName)));
            impersonatedUser.CommandExecuted += Log;
        }

        void Log(object sender, string command)
        {
            _logWriter.WriteLine("Command executed: {0}", command);
            _logWriter.Flush();
        }

        public void Dispose()
        {
            _logWriter.Dispose();
        }
    }
}
