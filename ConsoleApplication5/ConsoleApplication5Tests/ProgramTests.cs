using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccessRights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace AccessRights.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CreateRuleSetTest()
        {
            
            string filename = @"C:\FileAccessTest.txt";
            AuthorizationRuleCollection ruleset = Program.CreateRuleSet(filename);
            Assert.IsInstanceOfType(ruleset, typeof(AuthorizationRuleCollection));
        }

        [TestMethod()]
        public void PrintRulesTest()
        {
            string filename = @"C:\FileAccessTest.txt";
            AuthorizationRuleCollection ruleset = Program.CreateRuleSet(filename);
            Program.PrintRules(ruleset);
            Assert.Fail();
        }
    }
}