using System;
using System.Collections.Generic;

namespace MedApp_Api.DatabaseModels;

public partial class Appointment
{
    public string RecordId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public DateTime? AppointmentDate { get; set; }

    public string? DoctorId { get; set; }

    public string? Status { get; set; }

    public string? Comments { get; set; }

    public virtual User? Doctor { get; set; }

    public virtual User? Patient { get; set; }
    public virtual ICollection<Prescription>? Prescriptions { get; set; }
}
