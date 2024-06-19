using Microsoft.EntityFrameworkCore;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Core.Models;
using TrainTimings.Persistence.Data.Context;

namespace TrainTimings.Persistence.Repositories;

public class TrainsRepository : ITrainsRepository
{
    private readonly DataContext _dataContext;
    
    public TrainsRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Train> GetTrainByIdAsync(int id)
    {
        return await _dataContext.Trains.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Train> GetTrainByNumberAsync(string number)
    {
        return await _dataContext.Trains.FirstOrDefaultAsync(x => x.Number == number);
    }

    public async Task<List<Train>> GetAllTrainsAsync()
    {
        return await _dataContext.Trains.ToListAsync();
    }

    public async Task<Train> CreateTrainAsync(Train train)
    {
        await _dataContext.Trains.AddAsync(train);
        await _dataContext.SaveChangesAsync();
        
        return train;
    }

    public async Task<Train> UpdateTrainAsync(Train train)
    {
        _dataContext.Trains.Update(train);
        await _dataContext.SaveChangesAsync();
        
        return train;
    }

    public async Task DeleteTrainAsync(Train train)
    {
        _dataContext.Trains.Remove(train);
        await _dataContext.SaveChangesAsync();
    }
}