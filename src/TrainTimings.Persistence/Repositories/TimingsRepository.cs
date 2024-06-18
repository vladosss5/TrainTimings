using Microsoft.EntityFrameworkCore;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Core.Models;
using TrainTimings.Persistence.Data.Context;

namespace TrainTimings.Persistence.Repositories;

public class TimingsRepository : ITimingsRepository
{
    private readonly DataContext _dataContext;
    
    public TimingsRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Timing> GetTimingByIdAsync(int id)
    {
        return await _dataContext.Timings.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Timing>> GetAllTimingsAsync()
    {
        return await _dataContext.Timings.ToListAsync();
    }

    public async Task<Timing> CreateTimingAsync(Timing timing)
    {
        await _dataContext.Timings.AddAsync(timing);
        await _dataContext.SaveChangesAsync();
        
        return timing;
    }

    public async Task<Timing> UpdateTimingAsync(Timing timing)
    {
        _dataContext.Timings.Update(timing);
        await _dataContext.SaveChangesAsync();
        
        return timing;
    }

    public async Task DeleteTimingAsync(Timing timing)
    {
        _dataContext.Timings.Remove(timing);
        await _dataContext.SaveChangesAsync();
    }
}