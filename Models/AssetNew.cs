using System;
using System.Collections.Generic;

namespace WebApi25Dec.Models;

public partial class AssetNew
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
