using System;
using System.Collections.Generic;

namespace MedApp_Api.DatabaseModels;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Appointment>? AppointmentDoctors { get; set; }

    public virtual ICollection<Appointment>? AppointmentPatients { get; set; }

    public virtual InformationDoctor? InformationDoctor { get; set; }

    public virtual ICollection<UserInformation>? UserInformations { get; set; }

    public virtual ICollection<Role>? Roles { get; set; }
}
