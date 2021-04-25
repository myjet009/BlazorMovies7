using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public interface IMoviesRepository
    {
        Task<int> CraeteMovie(Movie movie);
        Task DeleteMovie(int Id);
        Task<DetailsMovieDTO> GetDetailsDTO(int id);
        Task<IndexPageDTO> GetIndexPageDTO();
        Task<MovieUpdateDTO> GetMovieForUpdate(int id);
        Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filterMoviesDTO);
        Task UpdateMovie(Movie movie);
    }
}
