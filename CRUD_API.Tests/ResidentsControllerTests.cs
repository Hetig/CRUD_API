using CRUD_API.Controllers;
using CRUD_API.Interfaces;
using CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System.Net;
using Xunit;

namespace CRUD_API.Tests
{
	public class ResidentsControllerTests
	{
		private readonly ResidentsController _residentController;
		private readonly Mock<IResidentStorage> _mockResidentStorage;
		public ResidentsControllerTests()
		{
			_mockResidentStorage = new Mock<IResidentStorage>();
			_residentController = new ResidentsController(_mockResidentStorage.Object);
		}


		[Fact]
		public void GetAllResult200()
		{
			var result = _residentController.GetAll(new ComplexFilter
			{
				AgeFilter = new AgeFilter { StartAge = 0, EndAge = 0 },
				SexFilter = new SexFilter { Sex = "string" },
				OwnerParameters = new OwnerParameters { PageNumber = 1, PageSize = 20 }
			}) as OkObjectResult;

			Assert.Equal(200, result.StatusCode);
		}

		[Fact]
		public void GetByIdResult200()
		{
			var result = _residentController.GetById("qyfgqiyhwfoq1") as OkObjectResult;
			
			Assert.Equal(200, result.StatusCode);
		}

	}
}