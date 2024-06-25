using System;
using System.Collections.Generic;

namespace CountryAPI.Models;

public partial class Town
{
    public Guid Id { get; set; }

    public string TownName { get; set; } = null!;

    public Guid? DistrictId { get; set; }
    public int? Population {  get; set; }

    public virtual ICollection<Commune> Communes { get; set; } = new List<Commune>();

    public virtual District? District { get; set; }
}
