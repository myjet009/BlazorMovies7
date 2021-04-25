using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/people";

        public PersonRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO)
        {
            return await _httpService.GetHelper<List<Person>>(url, paginationDTO);
        }

        public async Task<List<Person>> GetPeopleByName(string name)
        {
            var response = await _httpService.Get<List<Person>>($"{url}/search/{name}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<Person> GetPeopleById(int Id)
        {
            return await _httpService.GetHelper<Person>($"{url}/{Id}");
        }

        public async Task CraetePerson(Person person)
        {
            var response = await _httpService.Post(url, person);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdatePerson(Person person)
        {
            var response = await _httpService.Put(url, person);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeletePerson(int Id)
        {
            var response = await _httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
