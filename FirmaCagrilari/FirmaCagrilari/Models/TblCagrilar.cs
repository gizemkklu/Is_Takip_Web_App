using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblCagrilar
{
    public int Id { get; set; }

    public int? CagriFirma { get; set; }

    public string? Konu { get; set; }

    public string? Aciklama { get; set; }

    public bool? Durum { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual TblFirmalar? CagriFirmaNavigation { get; set; }

    public virtual ICollection<TblCagriDetay> TblCagriDetays { get; set; } = new List<TblCagriDetay>();
}
