using System;

namespace FlyPack.Domain.Entities
{
    public class Supplier : Person
    {
        public string Category { get; private set; } // e.g., "Freelancer", "Company"

        public ICollection<Product> Products { get; private set; }

        public Supplier(string name, string personType, string cpfCnpj, string email, string phone, string address, string category)
            : base(name, personType, cpfCnpj, email, phone, address)
        {
            Category = category;
            Products = new List<Product>();
        }

        public void UpdateCategory(string category)
        {
            Category = category;
        }
    }

}
