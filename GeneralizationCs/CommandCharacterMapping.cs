using System;
using System.Collections.Generic;

namespace GeneralizationCs
{
    public class CommandCharacterMapping
    {
        private static Dictionary<Type, char[]> commandMappings;

        static CommandCharacterMapping()
        {
            commandMappings = new Dictionary<Type, char[]>
            {
                {typeof (LoginCommand), new[] {(char) 0x01}},
                {typeof (AddEmployeeCmd), new[] {(char) 0x02}}
            };
        }

        public static char[] GetCommandCharacter(Type type)
        {
            return commandMappings[type];
        }
    }
}