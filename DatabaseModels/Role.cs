using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedApp_Api.DatabaseModels;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Priority { get; set; }

    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }
}
