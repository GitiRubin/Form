using System;
using System.Collections.Generic;

namespace Repositories.E;

public partial class Child
{
    public int ChildId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public int ParentId { get; set; }
}
