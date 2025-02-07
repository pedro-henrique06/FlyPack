namespace FlyPack.Domain.Entities
{
    public class Customer : Person
    {
        public string Notes { get; private set; }

        public Customer(string name, string personType, string cpfCnpj, string email, string phone, string address, string notes)
            : base(name, personType, cpfCnpj, email, phone, address)
        {
            Notes = notes;
        }

        public void UpdateNotes(string notes)
        {
            Notes = notes;
        }
    }
}
