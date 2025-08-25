using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace minimal_api.Dominio.Entidades {
    public class Veiculo {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(160)]
        public string Nome { get; set; } = default!;

        [Required]
        [StringLength(102)]
        public string Marca { get; set; } = default!;

        [Required]
        [StringLength(10)]
        public int Ano { get; set; } = default!;
    }
}