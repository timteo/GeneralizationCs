using System;
using System.IO;

namespace GeneralizationCs
{
	public class LoginCommand
	{
		private string name;
		private string password;
        
		private static char[] commandChar = {(char)0x01};



		public LoginCommand(string name, string password)
		{
			this.name = name;
			this.password = password;
		}

		private int getSize() {
			return Constant.Header.Length + Constant.SIZE_LENGTH + Constant.CMD_BYTE_LENGTH + Constant.Footer.Length +
				name.Length + 1 +
				password.Length + 1;
		}
		public void Write(TextWriter writer) {
			writer.Write(Constant.Header);
			writer.Write(getSize());
			writer.Write(commandChar);
			writer.Write(name);
			writer.Write(Constant.SEPERATOR);
			writer.Write(password);
			writer.Write(Constant.SEPERATOR);
			writer.Write(Constant.Footer);
		}
	}
}
