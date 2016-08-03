using System;
using System.IO;

namespace GeneralizationCs
{

	public class AddEmployeeCmd
	{
		private static char[] commandChar = {(char)0x02};


		private string name;
		private string address;
		private string city;
		private string state;
		private string yearlySalary;

		public AddEmployeeCmd(string name, string address, string city, string state, int yearlySalary)
		{
			this.name = name;
			this.address = address;
			this.city = city;
			this.state = state;
			this.yearlySalary = yearlySalary + "";
		}

		private int getSize() {
			return Constant.header.Length + Constant.SIZE_LENGTH + Constant.CMD_BYTE_LENGTH + Constant.footer.Length +
				name.Length + 1 +
				address.Length + 1 +
				city.Length + 1 +
				state.Length + 1 +
				yearlySalary.Length + 1;
		}


		public void Write(TextWriter writer) {
			writer.Write(Constant.header);
			writer.Write(getSize());
			writer.Write(commandChar);
			writer.Write(name);
			writer.Write(Constant.SEPERATOR);
			writer.Write(address);
			writer.Write(Constant.SEPERATOR);
			writer.Write(city);
			writer.Write(Constant.SEPERATOR);
			writer.Write(state);
			writer.Write(Constant.SEPERATOR);
			writer.Write(yearlySalary);
			writer.Write(Constant.SEPERATOR);
			writer.Write(Constant.footer);
		}
	}
}
