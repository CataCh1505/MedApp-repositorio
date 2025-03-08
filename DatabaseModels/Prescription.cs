using System;
using System.Collections.Generic;

namespace MedApp_Api.DatabaseModels;

public partial class Prescription
{
    public string RecordId { get; set; } = null!;

    public string PatientId { get; set; } = null!;

    public string AppointmentId { get; set; } = null!;

    public string Medicines { get; set; } = null!;

    public string Periodicity { get; set; } = null!;

    public byte Quantity { get; set; }

    public byte Period { get; set; }

    public byte Measurment { get; set; }

    public virtual Appointment? Appointment { get; set; }
}
