namespace GeneralizationCs
{
    public class LoginCommand : CommandWriter
    {
        private string name;
        private string password;


        public LoginCommand(string name, string password)
            : base(CommandCharacterMapping.CommandMappings[typeof (LoginCommand)])
        {
            this.name = name;
            this.password = password;
        }

        protected override void AddCommandParamters()
        {
            AddCommandParamters(name, password);
        }
    }
}