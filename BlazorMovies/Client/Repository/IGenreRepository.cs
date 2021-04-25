using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public interface IGenreRepository
    {
        Task CraeteGenre(Genre genre);
        Task<List<Genre>> GetGenres();
        Task<Genre> GetGenres(int Id);
        Task UpdateGenre(Genre genre);
        Task DeleteGenre(int Id);
    }
}
