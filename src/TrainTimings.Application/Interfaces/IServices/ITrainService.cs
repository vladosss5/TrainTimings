using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IServices;

public interface ITrainService
{
    public Task<Train> GetByIdAsync(int id);
    public Task<Train> GetByNumberAsync(string number);
    public Task<List<Train>> GetAllAsync();
    public Task<Train> CreateAsync(Train train);
    public Task<Train> UpdateAsync(Train train);
    public Task DeleteAsync(int id);
}