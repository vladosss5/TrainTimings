using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IServices;

public interface ICityService
{
    public Task<List<City>> GetAllAsync();
    public Task<City> GetByIdAsync(int id);
    public Task<City> CreateAsync(City city);
    public Task<City> UpdateAsync(City city);
    public Task DeleteAsync(int id);
}