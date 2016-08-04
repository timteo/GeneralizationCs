namespace GeneralizationCs
{
    public class Constant
    {
        public const int SIZE_LENGTH = 1;
        public const int CMD_BYTE_LENGTH = 1;
        public const char SEPERATOR = (char) 0x00;
        public static readonly char[] Header = {(char) 0xde, (char) 0xad};
        public static readonly char[] Footer = {(char) 0xbe, (char) 0xef};
    }
}