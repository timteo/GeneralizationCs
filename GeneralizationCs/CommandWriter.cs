using System.Collections.Generic;
using System.IO;

namespace GeneralizationCs
{
    public abstract class CommandWriter
    {
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
            return Constant.Header.Length + Constant.SIZE_LENGTH + Constant.CMD_BYTE_LENGTH + Constant.Footer.Length;
        }

        public void Write(TextWriter writer)
        {
            AddCommandParamters();

            writer.Write(Constant.Header);
            writer.Write(GetMessageSize());
            writer.Write(commandChar);

            foreach (var parameters in CommandParameterList)
            {
                writer.Write(parameters);
                writer.Write(Constant.SEPERATOR);
            }

            writer.Write(Constant.Footer);
        }
    }
}