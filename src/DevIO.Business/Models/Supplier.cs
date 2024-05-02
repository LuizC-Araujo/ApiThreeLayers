namespace DevIO.Business.Models
{
    public class Supplier : Entity
    {
        public Guid SupplierId { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public SupplierType SupplierType { get; set; }
        public bool Active { get; set; }
        public Address? Address { get; set; }

        //EF Relation
        public IEnumerable<Product> Products { get; set; }
    }
}
