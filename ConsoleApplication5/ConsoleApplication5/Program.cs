using static System.Console;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace AccessRights
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\FileAccessTest.txt";
            AuthorizationRuleCollection ruleset = CreateRuleSet(filename);
            PrintRules(ruleset);

         
        }

        public static AuthorizationRuleCollection CreateRuleSet(string filename)
        {
            using (FileStream stream = File.Open(filename, FileMode.Open))
            {
                FileSecurity securityAC = stream.GetAccessControl();
                AuthorizationRuleCollection ruleSet = securityAC.GetAccessRules(true, true, typeof(NTAccount));
                return ruleSet;


            }
        }
        public static void PrintRules(AuthorizationRuleCollection ruleSet)
        {
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
