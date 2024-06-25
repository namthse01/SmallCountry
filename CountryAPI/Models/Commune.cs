using System;
using System.Collections.Generic;

namespace CountryAPI.Models;

public partial class Commune
{
    public Guid Id { get; set; }

    public string CommuneName { get; set; } = null!;
    public int? Population {  get; set; }

    public Guid? TownId { get; set; }

    public virtual Town? Town { get; set; }
}
