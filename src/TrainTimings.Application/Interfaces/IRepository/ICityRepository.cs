using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IRepository;

public interface ICityRepository
{
    public Task<City> GetCityByIdAsync(int id);
    public Task<List<City>> GetAllCitiesAsync();
    public Task<City> CreateCityAsync(City city);
    public Task<City> UpdateCityAsync(City city);
    public Task DeleteCityAsync(City city);
}