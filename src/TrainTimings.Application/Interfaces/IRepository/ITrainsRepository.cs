using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IRepository;

public interface ITrainsRepository
{
    public Task<Train> GetTrainByIdAsync(int id);
    public Task<List<Train>> GetAllTrainsAsync();
    public Task<Train> CreateTrainAsync(Train train);
    public Task<Train> UpdateTrainAsync(Train train);
    public Task DeleteTrainAsync(Train train);
}