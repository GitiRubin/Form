using System;
using System.Collections.Generic;

namespace Repositories.E;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Type { get; set; } = null!;

    public string Hmo { get; set; } = null!;
}
