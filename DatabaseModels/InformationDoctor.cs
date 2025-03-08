using System;
using System.Collections.Generic;

namespace MedApp_Api.DatabaseModels;

public partial class InformationDoctor
{
    public string UserId { get; set; } = null!;

    public string? Speciality { get; set; }

    public bool? Monday { get; set; }

    public bool? Tuesday { get; set; }

    public bool? Wednesday { get; set; }

    public bool? Thursday { get; set; }

    public bool? Friday { get; set; }

    public bool? Satudary { get; set; }

    public bool? Sunday { get; set; }

    public byte? MondayTime { get; set; }

    public byte? TuesdayTime { get; set; }

    public byte? WednesdayTime { get; set; }

    public byte? ThursdayTime { get; set; }

    public byte? FridayTime { get; set; }

    public byte? SatudaryTime { get; set; }

    public byte? SundayTime { get; set; }

    public virtual User? User { get; set; }
}
