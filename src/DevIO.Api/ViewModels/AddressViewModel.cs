using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Number { get; set; }
        public string? Complement { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Neighborhood { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? City { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? State { get; set; }

        public Guid SupplierId { get; set; }
    }
}
