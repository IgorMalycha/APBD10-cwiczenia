using APBD9_pracadomowa.DTOs;
using APBD9_pracadomowa.Models;

namespace APBD9_pracadomowa.Services;

public interface IDbServices
{
    Task<bool> DoesPatientExist(int IdPatient);
    Task AddPatient(PatientDTO patient);
    Task<int> DoesMedicationsExist(IEnumerable<Medicament> medicaments);
    
}