using System;
using System.Collections.Generic;

namespace CountryAPI.Models;

public partial class City
{
    public Guid Id { get; set; }

    public string CityName { get; set; } = null!;

    public int? Population { get; set; }
}
