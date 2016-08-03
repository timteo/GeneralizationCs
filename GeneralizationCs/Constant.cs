namespace GeneralizationCs
{
    public class Constant
    {
        public const int SIZE_LENGTH = 1;
        public const int CMD_BYTE_LENGTH = 1;
        public static char[] header = {(char) 0xde, (char) 0xad};
        public static char[] commandChar = {(char) 0x01};
        public static char[] footer = {(char) 0xbe, (char) 0xef};
    }
}