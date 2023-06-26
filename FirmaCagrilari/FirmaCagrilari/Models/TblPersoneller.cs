using System;
using System.Collections.Generic;

namespace FirmaCagrilari.Models;

public partial class TblPersoneller
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Mail { get; set; }

    public string? Number { get; set; }

    public string? Image { get; set; }

    public int? Departman { get; set; }

    public bool? Durum { get; set; }

    public virtual TblDepartmanlar? DepartmanNavigation { get; set; }

    public virtual ICollection<TblGorevler> TblGorevlerGorevAlanNavigations { get; set; } = new List<TblGorevler>();

    public virtual ICollection<TblGorevler> TblGorevlerGorevVerenNavigations { get; set; } = new List<TblGorevler>();
}
