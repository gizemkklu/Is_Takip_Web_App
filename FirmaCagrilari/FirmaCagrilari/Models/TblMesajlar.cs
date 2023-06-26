using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblMesajlar
{
    public int Id { get; set; }

    public int? Gonderen { get; set; }

    public int? Alici { get; set; }

    public string? Konu { get; set; }

    public string? Mesaj { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Durum { get; set; }

    public virtual TblFirmalar? AliciNavigation { get; set; }

    public virtual TblFirmalar? GonderenNavigation { get; set; }
}
