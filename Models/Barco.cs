using System;
using System.Collections.Generic;

namespace ApiClubNautico.Models;

public partial class Barco
{
    public int Id { get; set; }

    public int IdSocio { get; set; }

    public int NumMatricula { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumAmarre { get; set; }

    public double Cuota { get; set; }

    public virtual Socio IdSocioNavigation { get; set; } = null!;
}
