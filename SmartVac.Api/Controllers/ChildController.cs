using Microsoft.AspNetCore.Mvc;
using SmartVac.Api.Db;
using SmartVac.Api.Models;
using SmartVac.Api.Models.User;
using System.Threading.Tasks;

namespace SmartVac.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildController : ControllerBase
    {
        private readonly IChildRepository _childRepository;

        public ChildController(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }
    }
}
