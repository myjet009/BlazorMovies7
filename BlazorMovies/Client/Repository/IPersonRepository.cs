using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public interface IPersonRepository
    {
        Task CraetePerson(Person person);
        Task DeletePerson(int Id);
        Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO);
        Task<Person> GetPeopleById(int Id);
        Task<List<Person>> GetPeopleByName(string name);
        Task UpdatePerson(Person person);
    }
}
