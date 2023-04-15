using CRUD_API.Interfaces;
using CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ResidentsController : ControllerBase
	{
		private readonly IResidentStorage _residentStorage;
		public ResidentsController(IResidentStorage residentStorage)
		{
			_residentStorage = residentStorage;
		}

		[HttpPost]
		public IActionResult GetAll(ComplexFilter complexFilter)
		{
			var filteredResidents = _residentStorage.GetAll(complexFilter.AgeFilter, complexFilter.SexFilter, complexFilter.OwnerParameters);
			return Ok(filteredResidents);
		}

		[HttpGet]
		public IActionResult GetById(string id)
		{
			return Ok(_residentStorage.GetResident(id));
		}
	}
}
