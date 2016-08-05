using System.Collections.Generic;
using System.IO;

namespace GeneralizationCs
{
    public abstract class CommandWriter
    {
        public const char SEPERATOR = (char) 0x00;
        public static readonly char[] Header = {(char) 0xde, (char) 0xad};
        public static readonly char[] Footer = {(char) 0xbe, (char) 0xef};

        public List<string> CommandParameterList { get; }
        public char[] CommandChar { get; }

        protected CommandWriter(char[] commandChar)
        {
            CommandParameterList = new List<string>();
            CommandChar = commandChar;
        }

        protected void AddCommandParameters(params string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                CommandParameterList.Add(parameter);
            }
        }

        protected abstract void AddCommandParameters();

        private int GetMessageSize()
        {
            int parametersSize = 0;
            foreach (var parameter in CommandParameterList)
            {
                parametersSize += parameter.Length + 1;
            }
            int totalSize = GetFixedHeadersSize(parametersSize) + parametersSize;
            return totalSize;
        }

        private int GetFixedHeadersSize(int parameterSize)
        {
            return Header.Length +
                   parameterSize.ToString().Length +
                   CommandChar.Length +
                   Footer.Length;
        }

        public void Write(TextWriter writer)
        {
            AddCommandParameters();

            writer.Write(Header);
            writer.Write(GetMessageSize());
            writer.Write(CommandChar);

            foreach (var parameters in CommandParameterList)
            {
                writer.Write(parameters);
                writer.Write(SEPERATOR);
            }

            writer.Write(Footer);
        }
    }
}