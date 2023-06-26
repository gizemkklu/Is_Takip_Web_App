using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblGorevler
{
    public int Id { get; set; }

    public int? GorevAlan { get; set; }

    public int? GorevVeren { get; set; }

    public string? Aciklama { get; set; }

    public bool? Durum { get; set; }

    public DateTime? Tarih { get; set; }

    public virtual TblPersoneller? GorevAlanNavigation { get; set; }

    public virtual TblPersoneller? GorevVerenNavigation { get; set; }

    public virtual ICollection<TblGorevDetay> TblGorevDetays { get; set; } = new List<TblGorevDetay>();
}
