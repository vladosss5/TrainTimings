using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IRepository;

public interface ITimingsRepository
{
    public Task<Timing> GetTimingByIdAsync(int id);
    public Task<List<Timing>> GetAllTimingsAsync();
    public Task<Timing> CreateTimingAsync(Timing timing);
    public Task<Timing> UpdateTimingAsync(Timing timing);
    public Task DeleteTimingAsync(Timing timing);
}