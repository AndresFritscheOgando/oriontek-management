using System;
using System.Collections.Generic;

namespace Oriontek_management.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Empresa { get; set; }

    public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
}
