namespace GeneralizationCs
{
    public class AddEmployeeCmd : CommandWriter
    {
        private Employee employee;

        public AddEmployeeCmd(Employee employee)
            : base(CommandCharacterMapping.GetCommandCharacter(typeof (AddEmployeeCmd)))
        {
            this.employee = employee;
        }

        protected override void AddCommandParameters()
        {
            AddCommandParameters(employee.Name, employee.Address,
                                 employee.City, employee.State,
                                 employee.YearlySalary.ToString());
        }
    }
}