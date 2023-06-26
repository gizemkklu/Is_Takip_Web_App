using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblDepartmanlar
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TblPersoneller> TblPersonellers { get; set; } = new List<TblPersoneller>();
}
