using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SmartVac.Api.Db;
using SmartVac.Api.Db.Child;
using System.Data;
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
