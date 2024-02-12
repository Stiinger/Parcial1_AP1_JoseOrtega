
using System.ComponentModel.DataAnnotations;

namespace Parcial1_AP1_JoseOrtega.Models;

public class Metas
{
    [Key]
    public int MetaId { get; set; }
    [Required(ErrorMessage = "Es obligatorio introducir la descripción.")]
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    [Range(1, 1000000000, ErrorMessage = "El monto debe ser mayor a 0.")]
    public decimal Monto { get; set; }
}