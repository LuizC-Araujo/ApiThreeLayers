namespace DevIO.Business.Models
{
    public class Address : Entity
    {
        public string? Logradouro { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Cep { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        // EF Relation
        public Supplier Supplier { get; set; }
    }
}
