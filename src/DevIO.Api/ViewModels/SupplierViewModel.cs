using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Document { get; set; }
        public int SupplierType { get; set; }
        public bool Active { get; set; }
        public AddressViewModel? Address { get; set; } 
        public IEnumerable<ProductViewModel>? Products { get; set; }
    }
}
