using Microsoft.EntityFrameworkCore;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Core.Models;
using TrainTimings.Persistence.Data.Context;

namespace TrainTimings.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly DataContext _dataContext;
    
    public CityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<City> GetCityByIdAsync(int id)
    {
        return await _dataContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<City>> GetAllCitiesAsync()
    {
        return await _dataContext.Cities.ToListAsync();
    }

    public async Task<City> CreateCityAsync(City city)
    {
        await _dataContext.Cities.AddAsync(city);
        await _dataContext.SaveChangesAsync();
        
        return city;
    }

    public async Task<City> UpdateCityAsync(City city)
    {
        _dataContext.Cities.Update(city);
        await _dataContext.SaveChangesAsync();
        
        return city;
    }

    public async Task DeleteCityAsync(City city)
    {
        _dataContext.Cities.Remove(city);
        await _dataContext.SaveChangesAsync();
    }
}