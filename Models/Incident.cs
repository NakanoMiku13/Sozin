using System;
using System.Collections.Generic;

namespace SozinBackNew.Models;

public partial class Incident
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Category { get; set; } = null!;

    public ulong? Active { get; set; }

    public DateTime? Begin { get; set; }

    public DateTime? End { get; set; }

    public int Command_Id { get; set; }

    public string Severity { get; set; } = null!;

    public string Material { get; set; } = null!;

    public int? Altitude { get; set; }

    public int? Size { get; set; }
}
