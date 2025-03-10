using System.ComponentModel.DataAnnotations;

namespace MiAppWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
    }
}
