using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsPrincipalSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPrincipalSample.Tests
{
    [TestClass()]
    public class ProgramTests
    {
     
        [TestMethod()]
        public void GetIDinfoTest()
        {
            
            WindowsIdentity id = Program.getIDinfo();
            Assert.IsInstanceOfType(id, typeof(WindowsIdentity));

            
            
        }

        [TestMethod()]
        public void GetPRinfoTest()
        {
            WindowsIdentity id = Program.getIDinfo();
            WindowsPrincipal pr = Program.getPRinfo(id);
            Assert.IsInstanceOfType(pr, typeof(WindowsIdentity));
        }

        [TestMethod()]
        public void ClaimsDisplayTest()
        {
            WindowsIdentity id = Program.getIDinfo();
            WindowsPrincipal pr = Program.getPRinfo(id);
            Program.ClaimsDisplay(pr.Claims);
            Assert.Fail();
        }
    }
}