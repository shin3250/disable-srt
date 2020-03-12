using System;
using System.IO;
using System.Media;

namespace disable_srt {
    class Program {
        static void Main(string[] args) {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var SwReporter = userProfile + @"\AppData\Local\Google\Chrome\User Data\SwReporter";

            foreach(var filePath in Directory.GetFiles(SwReporter, "software_reporter_tool.exe", SearchOption.AllDirectories)) {
                try {
                    var fileSecurity = File.GetAccessControl(filePath);
                    fileSecurity.SetAccessRuleProtection(true, false);
                    File.SetAccessControl(filePath, fileSecurity);

                    if(args.Length == 0) SystemSounds.Beep.Play();
                } catch {
                    try { if(args.Length == 0) SystemSounds.Hand.Play(); } catch { }
                }
            }

        }
    }
}
