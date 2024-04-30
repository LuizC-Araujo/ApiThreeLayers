namespace DevIO.Business.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}