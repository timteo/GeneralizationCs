namespace GeneralizationCs
{
    public class Employee
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int YearlySalary { get; set; }

        public Employee(string name, string address, string city, string state, int yearlySalary)
        {
            Name = name;
            Address = address;
            City = city;
            State = state;
            YearlySalary = yearlySalary;
        }
    }
}