using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace GeneralizationCs
{
    [TestFixture]
    public class AddEmployeeCmdTest
    {
        public static IEnumerable<TestCaseData> GetTestEmployee()
        {
            yield return new TestCaseData(new Employee("Fred Brooks", "123 My House", "Springfield", "IL", 72000));
            yield return new TestCaseData(new Employee("Paul Creek", "840 Muse Yarn", "Flakog", "ZW", 84120));
        }

        [TestCaseSource(nameof(GetTestEmployee))]
        public void SentCorrectly(Employee employee)
        {
            string expected = CreateExpectedMessage(employee);

            AddEmployeeCmd cmd = new AddEmployeeCmd(employee);
            StringWriter writer = new StringWriter();
            cmd.Write(writer);

            Assert.AreEqual(expected, writer.ToString());
        }

        private string CreateExpectedMessage(Employee employee)
        {
            int dataLength = employee.Name.Length + 1;
            dataLength += employee.Address.Length + 1;
            dataLength += employee.City.Length + 1;
            dataLength += employee.State.Length + 1;
            dataLength += employee.YearlySalary.ToString().Length + 1;

            char[] commandChar = CommandCharacterMapping.GetCommandCharacter(typeof (AddEmployeeCmd));

            int totalSize = CommandWriter.Header.Length +
                            dataLength.ToString().Length +
                            commandChar.Length +
                            CommandWriter.Footer.Length +
                            dataLength;

            StringWriter sw = new StringWriter();
            sw.Write(CommandWriter.Header);
            sw.Write(totalSize);
            sw.Write(commandChar);
            sw.Write(employee.Name);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(employee.Address);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(employee.City);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(employee.State);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(employee.YearlySalary);
            sw.Write(CommandWriter.SEPERATOR);
            sw.Write(CommandWriter.Footer);

            return sw.ToString();
        }
    }
}