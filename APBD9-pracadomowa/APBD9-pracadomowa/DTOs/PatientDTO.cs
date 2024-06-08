using System.ComponentModel.DataAnnotations;

namespace APBD9_pracadomowa.DTOs;

public class PatientDTO
{
    public int IdPatient { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DataType BirthDate { get; set; }
    
}