using System;
using System.Collections.Generic;

namespace MedApp_Api.DatabaseModels;

public partial class UserInformation
{
    public string UserId { get; set; } = null!;

    public string RecordId { get; set; } = null!;

    public float Weight { get; set; }

    public float Height { get; set; }

    public string VitalSigns { get; set; } = null!;

    public virtual User? User { get; set; }
}
