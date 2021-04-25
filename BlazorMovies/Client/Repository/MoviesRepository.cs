using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/movies";

        public MoviesRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IndexPageDTO> GetIndexPageDTO()
        {
            return await _httpService.GetHelper<IndexPageDTO>(url);
            //return await Get<IndexPageDTO>(url);
        }

        public async Task<MovieUpdateDTO> GetMovieForUpdate(int id)
        {
            return await _httpService.GetHelper<MovieUpdateDTO>($"{url}/update/{id}");
        }

        public async Task<DetailsMovieDTO> GetDetailsDTO(int id)
        {
            var ddd = await _httpService.GetHelper<DetailsMovieDTO>($"{url}/{id}");
            return ddd;
            //return await Get<DetailsMovieDTO>($"{url}/{id}");
        }

        //private async Task<T> Get<T>(string url)
        //{
        //    var response = await _httpService.Get<T>(url);
        //    if (!response.Success)
        //    {
        //        throw new ApplicationException(await response.GetBody());
        //    }
        //    return response.Response;
        //}

        public async Task<PaginatedResponse<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filterMoviesDTO)
        {
            var responseHTTP = await _httpService.Post<FilterMoviesDTO, List<Movie>>($"{url}/filter", filterMoviesDTO);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<Movie>>()
            {
                Response = responseHTTP.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }

        public async Task<int> CraeteMovie(Movie movie)
        {
            var response = await _httpService.Post<Movie, int>(url, movie);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task UpdateMovie(Movie movie)
        {
            var response = await _httpService.Put(url, movie);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteMovie(int Id)
        {
            var response = await _httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
