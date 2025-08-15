
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oriontek_management.Models;


public class Direccion
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Calle { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Ciudad { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Pais { get; set; } = string.Empty;

    // Relacion con cliente
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }

    public Cliente? Cliente { get; set; }
}

