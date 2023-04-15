using CRUD_API.Models;
using CRUD_API.ViewModels;

namespace CRUD_API.Interfaces
{
	public interface IResidentStorage
	{
		List<Resident> GetAll(AgeFilter ageFilter, SexFilter sexFilter, OwnerParameters ownerParameters);
		ResidentViewModel GetResident(string id);
	}
}
