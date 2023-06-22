using System;
using System.Collections.Generic;

namespace ApiClubNautico.Models;

public partial class Socio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Barco> Barcos { get; set; } = new List<Barco>();
}
