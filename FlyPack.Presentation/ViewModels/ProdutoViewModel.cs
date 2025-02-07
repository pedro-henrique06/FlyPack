namespace FlyPack.Presentation.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
