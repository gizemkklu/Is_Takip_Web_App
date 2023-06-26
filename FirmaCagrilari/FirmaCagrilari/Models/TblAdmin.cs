using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblAdmin
{
    public int Id { get; set; }

    public string? Kullanici { get; set; }

    public string? Sifre { get; set; }
}
