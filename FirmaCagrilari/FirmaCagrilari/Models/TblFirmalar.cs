using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblFirmalar
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Competent { get; set; }

    public string? Number { get; set; }

    public string? Mail { get; set; }

    public string? Sifre { get; set; }

    public string? Sector { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Address { get; set; }

    public string? Gorsel { get; set; }

    public virtual ICollection<TblCagrilar> TblCagrilars { get; set; } = new List<TblCagrilar>();

    public virtual ICollection<TblMesajlar> TblMesajlarAliciNavigations { get; set; } = new List<TblMesajlar>();

    public virtual ICollection<TblMesajlar> TblMesajlarGonderenNavigations { get; set; } = new List<TblMesajlar>();
}
