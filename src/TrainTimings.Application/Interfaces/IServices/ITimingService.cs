using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IServices;

public interface ITimingService
{
    public Task<Timing> CreateTimingAsync(Timing timing);
    public Task<Timing> UpdateTimingAsync(Timing timing);
    public Task<Timing> GetTimingByIdAsync(int id);
    public Task<List<Timing>> GetAllTimingsAsync();
    public Task DeleteTimingAsync(int id);
}