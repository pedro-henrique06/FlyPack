namespace FlyPack.Domain.Entities
{
    public class Employee : Person
    {
        public string Position { get; private set; }
        public DateTime HireDate { get; private set; }

        public Employee(string name, string personType, string cpfCnpj, string email, string phone, string address, string position, DateTime hireDate)
            : base(name, personType, cpfCnpj, email, phone, address)
        {
            Position = position;
            HireDate = hireDate;
        }

        public void UpdatePosition(string position)
        {
            Position = position;
        }
    }
}
