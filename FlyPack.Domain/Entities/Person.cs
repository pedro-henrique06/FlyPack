using System.ComponentModel.DataAnnotations;

namespace FlyPack.Domain.Entities
{
    public abstract class Person : Entity
    {
        public string Name { get; protected set; }
        public string PersonType { get; protected set; }
        public string CpfCnpj { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public string Address { get; protected set; }
        public bool Active { get; protected set; } = true;

        protected Person(string name, string personType, string cpfCnpj, string email, string phone, string address)
        {
            Name = name;
            PersonType = personType;
            CpfCnpj = cpfCnpj;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public void UpdateDetails(string name, string email, string phone, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
