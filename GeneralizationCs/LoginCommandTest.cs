using System.IO;
using NUnit.Framework;

namespace GeneralizationCs
{
    [TestFixture]
    public class LoginCommandTest
    {
        [Test]
        public void SentCorrectly()
        {
            char[] knownGood =
            {
                (char) 0xde, (char) 0xad, (char) 50, (char) 48, (char) 0x01,
                'b', 'a', 'b', (char) 0x00,
                'c', 'a', 'r', 'd', 'i', 'n', 'a', 'l', 's', (char) 0x00,
                (char) 0xbe, (char) 0xef
            };

            LoginCredentials loginCredentials = new LoginCredentials("bab", "cardinals");
            LoginCommand cmd = new LoginCommand(loginCredentials);
            StringWriter writer = new StringWriter();
            cmd.Write(writer);

            for (int i = 0; i < knownGood.Length; i++)
            {
                Assert.AreEqual(knownGood[i], writer.ToString()[i], "comparison failed at byte number " + i);
            }
        }
    }
}