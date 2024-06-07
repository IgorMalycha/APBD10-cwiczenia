using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace APBD9_pracadomowa.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    public DateType Date { get; set; }

    public DateType DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    [ForeignKey(nameof(IdPatient))] 
    public Patient Patient { get; set; }

    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdDoctor))] 
    public Doctor Doctor { get; set; }
    
}