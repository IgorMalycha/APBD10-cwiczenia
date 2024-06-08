using APBD9_pracadomowa.Models;
using Microsoft.VisualBasic.CompilerServices;

namespace APBD9_pracadomowa.DTOs;

public class GetPrescriptionForPatient
{
    public PatientDTO Patient { get; set; }

    public ICollection<MedicamentDTO> Medicaments { get; set; }

    public DateType Date { get; set; }
    
    public DateType DueDate { get; set; }
    
}