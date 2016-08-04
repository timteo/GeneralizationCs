using System.Collections.Generic;
using System.IO;

namespace GeneralizationCs
{
    public abstract class CommandWriter
    {
        private const int SIZE_LENGTH = 1;
        private const char SEPERATOR = (char) 0x00;
        private static readonly char[] Header = {(char) 0xde, (char) 0xad};
        private static readonly char[] Footer = {(char) 0xbe, (char) 0xef};

        public List<string> CommandParameterList { get; }
        private readonly char[] commandChar;

        public CommandWriter(char[] commandChar)
        {
            CommandParameterList = new List<string>();
            this.commandChar = commandChar;
        }

        protected void AddCommandParamters(params string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                CommandParameterList.Add(parameter);
            }
        }

        protected abstract void AddCommandParamters();

        private int GetMessageSize()
        {
            int totalSize = GetFixedHeadersSize();
            foreach (var parameter in CommandParameterList)
            {
                totalSize += parameter.Length + 1;
            }
            return totalSize;
        }

        private int GetFixedHeadersSize()
        {
            return Header.Length + SIZE_LENGTH + commandChar.Length + Footer.Length;
        }

        public void Write(TextWriter writer)
        {
            AddCommandParamters();

            writer.Write(Header);
            writer.Write(GetMessageSize());
            writer.Write(commandChar);

            foreach (var parameters in CommandParameterList)
            {
                writer.Write(parameters);
                writer.Write(SEPERATOR);
            }

            writer.Write(Footer);
        }
    }
}