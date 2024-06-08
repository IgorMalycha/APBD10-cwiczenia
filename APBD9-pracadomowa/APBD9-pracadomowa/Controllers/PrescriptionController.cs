using APBD9_pracadomowa.DTOs;
using APBD9_pracadomowa.Models;
using APBD9_pracadomowa.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD9_pracadomowa.Controllers;

[Route("api/prescription")]
[ApiController]
public class PrescriptionController : ControllerBase
{

    private DbServices _dbServices;

    public PrescriptionController(DbServices dbServices)
    {
        _dbServices = dbServices;
    }

    [HttpPost]
    public async Task<IActionResult> PrescriptionForPatient(GetPrescriptionForPatient getPrescriptionForPatient)
    {
        if (await _dbServices.DoesPatientExist(getPrescriptionForPatient.Patient.IdPatient))
        {
           await _dbServices.AddPatient(getPrescriptionForPatient);
        }

        if (await _dbServices.DoesMedicationsExist(getPrescriptionForPatient.Medicaments))
        {
            return NotFound("Medication does not exist");
        }

        if (await _dbServices.IsAbove10Medication(getPrescriptionForPatient.Medicaments))
        {
            return NotFound("Above 10 Medications");
        }

        if (await _dbServices.IsDueDateLessDate(getPrescriptionForPatient))
        {
            return NotFound("DueDate is less then Date");
        }

        await _dbServices.AddPatient(getPrescriptionForPatient);
    
        return Created();
    }
    
    
}