using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnCryptDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnCryptDecrypt.Tests
{
    [TestClass()]
    public class frmMainTests
    {

        [TestMethod()]
        public void btnEncrypt_ClickTest()
        {
            frmMain frm = new frmMain();
            object one = new object();
            EventArgs two = new EventArgs();
            frm.btnEncrypt_Click(one,two);
            Assert.Fail();
        }

        [TestMethod()]
        public void btnDecrypt_ClickTest()
        {
            frmMain frm = new frmMain();
            object one = new object();
            EventArgs two = new EventArgs();
            frm.btnDecrypt_Click(one, two);
            Assert.Fail();
        }

    }
    }
