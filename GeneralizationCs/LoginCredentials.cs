namespace GeneralizationCs
{
    public class LoginCredentials
    {
        public string Name { get; }
        public string Password { get; }

        public LoginCredentials(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}