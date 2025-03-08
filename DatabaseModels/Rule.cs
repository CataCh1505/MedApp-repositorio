using System;
using System.Collections.Generic;

namespace MedApp_Api.DatabaseModels;

public partial class Rule
{
    public string RuleId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Range { get; set; } = null!;

    public string? Alphanumeric1 { get; set; }

    public string? Alphanumeric2 { get; set; }

    public int? Numeric1 { get; set; }

    public int? Numeric2 { get; set; }

    public DateTime? Time1 { get; set; }

    public DateTime? Time2 { get; set; }

    public bool? Logical { get; set; }
}
