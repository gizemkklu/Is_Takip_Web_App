using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblGorevDetay
{
    public int Id { get; set; }

    public int? Gorev { get; set; }

    public string? Aciklama { get; set; }

    public DateTime? Tarih { get; set; }

    public string? Saat { get; set; }

    public virtual TblGorevler? GorevNavigation { get; set; }
}
