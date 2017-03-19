using static System.Console;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace AccessRights
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\FileAccessTest.txt";

            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                FileSecurity securityAC = stream.GetAccessControl();
                AuthorizationRuleCollection ruleSet = securityAC.GetAccessRules(true, true, typeof(NTAccount));

                foreach (AuthorizationRule singleRule in ruleSet)
                {
                    var fr = singleRule as FileSystemAccessRule;
                    WriteLine($"User's Identity: {fr.IdentityReference.Value}");
                    WriteLine($"User's Access Type: {fr.AccessControlType}");
                    WriteLine($"User's Rights: {fr.FileSystemRights}");                    
                    WriteLine();
                }
            }
        }
    }
}
