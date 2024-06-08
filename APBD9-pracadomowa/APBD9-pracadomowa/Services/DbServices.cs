using System.Collections.ObjectModel;
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

    public async Task AddPatient(GetPrescriptionForPatient getPrescriptionForPatient)
    {
        _apbdContext.Patients.AddAsync(new Patient()
        {
            IdPatient = getPrescriptionForPatient.Patient.IdPatient,
            FirstName = getPrescriptionForPatient.Patient.FirstName,
            LastName = getPrescriptionForPatient.Patient.LastName,
            BirthDate = getPrescriptionForPatient.Patient.BirthDate
        });

        _apbdContext.SaveChanges();
    }
    public async Task<bool> DoesMedicationsExist(ICollection<GetMedicamentDTO> medicaments)
    {

        var meds = medicaments.Select(s => s.IdMedicament).ToList();

        var existingMeds = await _apbdContext.Medicaments.Where(c => meds.Contains(c.IdMedicament))
            .Select(c => c.IdMedicament).ToListAsync();

        return meds.All(c => existingMeds.Contains(c));
    }
    public async Task<bool> IsAbove10Medication(ICollection<GetMedicamentDTO> medicaments)
    {
        return 10 < medicaments.Select(c => c.IdMedicament).Count();
    }
    public async Task<bool> IsDueDateLessDate(GetPrescriptionForPatient getPrescriptionForPatient)
    {
        return getPrescriptionForPatient.DueDate <= getPrescriptionForPatient.Date;
    }

    public async Task AddPrescription(GetPrescriptionForPatient getPrescriptionForPatient)
    {
        _apbdContext.Prescriptions.AddAsync(new Prescription()
        {
            Date = getPrescriptionForPatient.Date,
            DueDate = getPrescriptionForPatient.DueDate,
            IdPatient = getPrescriptionForPatient.Patient.IdPatient
        });
        
        
        //do dokonczenia
    }

    public async Task<PatientInfoDTO> GetPatientInfo(int IdPatient)
    {
        
    }

}