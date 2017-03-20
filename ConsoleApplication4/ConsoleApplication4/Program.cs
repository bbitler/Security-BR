using static System.Console;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;



namespace WindowsPrincipalSample
{
   public class Program
    {
        public static void Main()
        {
            WindowsIdentity id = getIDinfo();

            WindowsPrincipal pr = getPRinfo(id);

            ClaimsDisplay(pr.Claims);
        }

        public static WindowsIdentity getIDinfo()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            if (id == null)
            {
                WriteLine("If you are reading this message this is not a Windows Identity");
                return null;
            }

            id.AddClaim(new Claim("Age", "33"));

            WriteLine($"What is the ID's type?: {id}");
            WriteLine($"What is the ID's name?: {id.Name}");
            WriteLine($"Is the ID a guest?: {id.IsGuest}");
            WriteLine($"Is this ID authenticated?: {id.IsAuthenticated}");
            WriteLine($"What is the authentication type?: {id.AuthenticationType}");
            WriteLine($"Is this ID anonymous? {id.IsAnonymous}");
            WriteLine($"What is the impersonation level of this ID?: {id.ImpersonationLevel}");
            WriteLine($"What is the ID's access token?: {id.AccessToken.DangerousGetHandle()}");
            WriteLine();
            return id;
        }

        public static WindowsPrincipal getPRinfo(WindowsIdentity id)
        {
            WriteLine("Display principal information");
            WindowsPrincipal pr = new WindowsPrincipal(id);
            if (pr == null)
            {
                WriteLine("If you are reading this message this is not a Windows Principal");
                return null;
            }
            WriteLine($"Is the principal in the users group? {pr.IsInRole(WindowsBuiltInRole.User)}");
            WriteLine($"Is the principal in the admin group? {pr.IsInRole(WindowsBuiltInRole.Administrator)}");
            WriteLine();
            return pr;
        }

        public static void ClaimsDisplay(IEnumerable<Claim> cl)
        {
            WriteLine("Claims");
            foreach (var claim in cl)
            {
                WriteLine($"What is the claim subject?: {claim.Subject}");
                WriteLine($"Who is the claim issuer?: {claim.Issuer}");
                WriteLine($"What is the claim type?: {claim.Type}");
                WriteLine($"What is the claim  value type?: {claim.ValueType}");
                WriteLine($"What is the claim value?: {claim.Value}");
                foreach (var prop in claim.Properties)
                {
                    WriteLine($"\tProperty: {prop.Key} {prop.Value}");
                }
                WriteLine();

            }
        }
    }
}
