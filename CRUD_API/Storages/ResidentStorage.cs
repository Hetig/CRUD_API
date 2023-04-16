using CRUD_API.Database;
using CRUD_API.Interfaces;
using CRUD_API.Models;
using CRUD_API.ViewModels;
using Newtonsoft.Json;

namespace CRUD_API.Storages
{
	public class ResidentStorage:IResidentStorage
	{
		private readonly AppDbContext _context;

        public ResidentStorage(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает информацию о жителях, отфильтрованных по переданным параметрам 
        /// </summary>
        /// <param name="ageFilter"></param>
        /// <param name="sexFilter"></param>
        /// <returns></returns>
        public List<Resident> GetAll(AgeFilter ageFilter, SexFilter sexFilter, OwnerParameters ownerParameters)
        {
            var residents = _context.Resident.ToList()
                                              .OrderBy(on => on.Name)
                                              .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
		                                      .Take(ownerParameters.PageSize)
		                                      .ToList();

			if (!(ageFilter.StartAge == 0 && ageFilter.EndAge == 0))
            {
                residents = residents.Where(res => GetResident(res.Id).Age >= ageFilter.StartAge 
                                                    && GetResident(res.Id).Age <= ageFilter.EndAge)
                                                    .ToList();
            }

            if(!(sexFilter.Sex == "string"))
            {
                residents = residents.Where(res => res.Sex == sexFilter.Sex).ToList(); 
            }

            return residents;
        }


        /// <summary>
        /// Возвращает жителя со всеми данными по переданному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResidentViewModel GetResident(string id)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Get, $"http://testlodtask20172.azurewebsites.net/task/{id}");

			var response = client.SendAsync(request).Result;
			response.EnsureSuccessStatusCode();
			var jsonString = response.Content.ReadAsStringAsync().Result;

            var resident = JsonConvert.DeserializeObject<ResidentViewModel>(jsonString);
            return resident;
		}
    }
}
