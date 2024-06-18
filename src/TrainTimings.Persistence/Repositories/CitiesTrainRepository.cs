using Microsoft.EntityFrameworkCore;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Core.Models;
using TrainTimings.Persistence.Data.Context;

namespace TrainTimings.Persistence.Repositories;

public class CitiesTrainRepository : ICitiesTrainRepository
{
    private readonly DataContext _dataContext;
    
    public CitiesTrainRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public async Task<CitiesTrain> GetCitiesTrainByIdAsync(int id)
    {
        return await _dataContext.CitiesTrains.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<CitiesTrain>> GetAllCitiesTrainsAsync()
    {
        return await _dataContext.CitiesTrains.ToListAsync();
    }

    public async Task<CitiesTrain> CreateCitiesTrainAsync(CitiesTrain citiesTrain)
    {
        await _dataContext.CitiesTrains.AddAsync(citiesTrain);
        await _dataContext.SaveChangesAsync();
        
        return citiesTrain;
    }

    public async Task<CitiesTrain> UpdateCitiesTrainAsync(CitiesTrain citiesTrain)
    {
        _dataContext.CitiesTrains.Update(citiesTrain);
        await _dataContext.SaveChangesAsync();
        
        return citiesTrain;
    }

    public async Task DeleteCitiesTrainAsync(CitiesTrain citiesTrain)
    {
        _dataContext.CitiesTrains.Remove(citiesTrain);
        await _dataContext.SaveChangesAsync();
    }
}