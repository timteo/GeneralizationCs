using System;
using System.Collections.Generic;

namespace GeneralizationCs
{
    public class CommandCharacterMapping
    {
        public static Dictionary<Type, char[]> CommandMappings { get; private set; }

        static CommandCharacterMapping()
        {
            CommandMappings = new Dictionary<Type, char[]>();
            CommandMappings.Add(typeof(LoginCommand), new char[] { (char)0x01 });
            CommandMappings.Add(typeof(AddEmployeeCmd), new char[] { (char)0x02 });
        }
    }
}