using System;
using System.Collections.Generic;

namespace CountryAPI.Models;

public partial class District
{
    public Guid Id { get; set; }

    public string DistrictName { get; set; } = null!;
    public int? Population {  get; set; }

    public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
}
