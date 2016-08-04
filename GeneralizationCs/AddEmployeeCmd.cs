namespace GeneralizationCs
{
    public class AddEmployeeCmd : CommandWriter
    {
        private string address;
        private string city;
        private string name;
        private string state;
        private string yearlySalary;

        public AddEmployeeCmd(string name, string address, string city, string state, int yearlySalary)
            : base(CommandCharacterMapping.CommandMappings[typeof (AddEmployeeCmd)])
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.yearlySalary = yearlySalary + "";
        }

        protected override void AddCommandParamters()
        {
            AddCommandParamters(name, address, city, state, yearlySalary);
        }
    }
}