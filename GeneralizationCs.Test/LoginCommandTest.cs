using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace GeneralizationCs 
{
    [TestFixture]
    public class LoginCommandTest
    {
        public static IEnumerable<TestCaseData> GetTestLogin() {
            yield return new TestCaseData(new LoginCredentials("bab", "cardinals"));
            yield return new TestCaseData(new LoginCredentials("rand", "om name"));
        }

        [TestCaseSource("GetTestLogin")]
        public void SentCorrectly(LoginCredentials loginCredentials) {

            string expected = CreateExpectedMessage(loginCredentials);

            LoginCommand cmd = new LoginCommand(loginCredentials);
            StringWriter writer = new StringWriter();
            cmd.Write(writer);

            Assert.AreEqual(expected, writer.ToString());

        }

        private string CreateExpectedMessage(LoginCredentials loginCredentials) {
            int dataLength = loginCredentials.Name.Length + 1;
            dataLength += loginCredentials.Password.Length + 1;

            char[] commandChar = CommandCharacterMapping.GetCommandCharacter(typeof(LoginCommand));

            int totalSize = CommandWriter.Header.Length +
                dataLength.ToString().Length +
                commandChar.Length +
                CommandWriter.Footer.Length +
                dataLength;

            StringWriter sw = new StringWriter();
            sw.Write(CommandWriter.Header);
            sw.Write(totalSize);
            sw.Write(commandChar);
            sw.Write(loginCredentials.Name);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(loginCredentials.Password);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(CommandWriter.Footer);

            return sw.ToString();
        }
    }
}