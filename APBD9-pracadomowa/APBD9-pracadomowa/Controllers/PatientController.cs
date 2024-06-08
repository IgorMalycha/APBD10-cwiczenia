using APBD9_pracadomowa.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD9_pracadomowa.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientController : ControllerBase
{
    private DbServices _dbServices;

    public PatientController(DbServices dbServices)
    {
        _dbServices = dbServices;
    }

    [HttpGet("{IdPatient}")]
    public async Task<IActionResult> GetPatientInfo(int IdPatient)
    {

        var result = _dbServices.GetPatientInfo(IdPatient);
            
        return Ok(result);
    }
    
    
}