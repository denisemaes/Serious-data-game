using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class dimlocation
{
    public int LocationId { get; set; }
    public int ParentId { get; set; }
    public int LevelId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public int Population { get; set; }
    public string Geometry { get; set; }
    public bool IsActive { get; set; }
    public bool FlagPlaceDouble { get; set; }
    public bool FlagMunicipalityDouble { get; set; }
    public bool FlagProvinceDouble { get; set; }
}