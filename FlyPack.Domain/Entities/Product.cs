namespace FlyPack.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; } = true;

        // Relationship with Supplier
        public Guid SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }

        public Product(string name, string description, decimal price, Guid supplierId)
        {
            Name = name;
            Description = description;
            Price = price;
            SupplierId = supplierId;
        }

        public void UpdateProduct(string name, string description, decimal price, Guid supplierId)
        {
            Name = name;
            Description = description;
            Price = price;
            SupplierId = supplierId;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
