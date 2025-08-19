using System;
using System.Collections.Generic;

namespace Oriontek_management.Models;

public partial class Direccion
{
    public int Id { get; set; }

    public string Calle { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
