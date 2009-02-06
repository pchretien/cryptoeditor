using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CryptoEditor;
using CryptoEditor.Framework;

using NUnit.Framework;
using UnitTests.CryptoEditorServiceBackup;

namespace UnitTests
{
    [TestFixture]
    public class CryptoEditorServiceTests
    {
        [Test]
        public void TestRegister()
        {
            CryptoEditorServiceBackup.BackupService client = new BackupService();
            int ret = client.Register("philippechretien@hotmail.com", "pchretien", "Philippe Chrétien");
            Assert.AreEqual(0, ret);
        }

        [Test]
        public void TestConfirm()
        {
            CryptoEditorServiceBackup.BackupService client = new BackupService();
            int ret = client.Confirm("philippechretien@hotmail.com", "5196e215-8a16-43ca-bc9b-4e2103742cb4");
            Assert.AreEqual(0, ret);
        }
    }
}
