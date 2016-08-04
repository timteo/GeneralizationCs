namespace GeneralizationCs
{
    public class LoginCommand : CommandWriter
    {
        public LoginCredentials LoginCredentials { get; }

        public LoginCommand(LoginCredentials loginCredentials)
            : base(CommandCharacterMapping.CommandMappings[typeof (LoginCommand)])
        {
            LoginCredentials = loginCredentials;
        }

        protected override void AddCommandParamters()
        {
            AddCommandParamters(LoginCredentials.Name, LoginCredentials.Password);
        }
    }
}