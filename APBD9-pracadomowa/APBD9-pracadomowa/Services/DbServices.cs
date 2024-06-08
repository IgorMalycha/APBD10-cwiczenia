using APBD9_pracadomowa.Context;
using APBD9_pracadomowa.DTOs;
using APBD9_pracadomowa.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD9_pracadomowa.Services;

public class DbServices : IDbServices
{

    private readonly APBDContext _apbdContext;

    public DbServices(APBDContext apbdContext)
    {
        _apbdContext = apbdContext;
    }

    public async Task<bool> DoesPatientExist(int IdPatient)
    {
        return await _apbdContext.Patients.Where(c => c.IdPatient == IdPatient).AnyAsync();
    }

    public async Task AddPatient(PatientDTO patient)
    {
        _apbdContext.Patients.AddAsync(new Patient()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate
        });

        _apbdContext.SaveChanges();
    }

    public async Task<int> DoesMedicationsExist(IEnumerable<Medicament> medicaments)
    {

        var meds = medicaments.Select(s => s.IdMedicament).ToList();
        
        var existingMeds = await _apbdContext.Medicaments.
            Where(c => c.IdMedicament == C)

    }
}