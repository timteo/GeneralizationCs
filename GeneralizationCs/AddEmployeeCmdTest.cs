using System;
using System.IO;
using NUnit.Framework;

namespace GeneralizationCs
{

	[TestFixture] public class AddEmployeeCmdTest
	{
		[Test] public void SentCorrectly() {
			char [] knownGood = { (char)0xde, (char)0xad, (char)53, (char)50, (char)0x02,
                                    'F', 'r', 'e', 'd', ' ', 'B', 'r', 'o', 'o', 'k', 's', Constant.SEPERATOR,
                                    '1', '2', '3', ' ', 'M', 'y', ' ', 'H', 'o', 'u', 's', 'e', Constant.SEPERATOR,
                                    'S', 'p', 'r', 'i', 'n', 'g', 'f', 'i', 'e', 'l', 'd', Constant.SEPERATOR,
                                    'I', 'L', Constant.SEPERATOR,
                                    '7', '2', '0', '0', '0', Constant.SEPERATOR,
                                    (char)0xbe, (char)0xef };

			AddEmployeeCmd cmd = new AddEmployeeCmd("Fred Brooks", "123 My House", "Springfield", "IL", 72000);
			StringWriter writer = new StringWriter();
			cmd.Write(writer);

			for( int i = 0; i < knownGood.Length; i++ ) {
				Assert.AreEqual(knownGood[i], writer.ToString()[i], "comparison failed at byte number " + i );
			}
		}
	}
}
