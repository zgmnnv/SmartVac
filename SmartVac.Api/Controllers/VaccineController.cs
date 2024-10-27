using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db.Vaccine;

namespace SmartVac.Api.Controllers;

public class VaccineController : ControllerBase
{
    private readonly IVaccineRepository _vaccineRepository;
    
    public VaccineController()
    {
        
    }
}