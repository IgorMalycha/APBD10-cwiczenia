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
           await _dbServices.AddPatient(getPrescriptionForPatient.Patient);
        }

        int medicationId = await _dbServices.DoesMedicationsExist(getPrescriptionForPatient.Medicaments);
        if (medicationId > -1)
        {
            return NotFound($"Medication with given id: {medicationId} doesn not exist");
        }
    
        return Created();
    }
    
    
}