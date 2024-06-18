using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IRepository;

public interface ITypesRepository
{
    public Task<TypeTrain> GetTypeByIdAsync(int id);
    public Task<List<TypeTrain>> GetAllTypesAsync();
    public Task<TypeTrain> CreateTypeAsync(TypeTrain typeTrain);
    public Task<TypeTrain> UpdateTypeAsync(TypeTrain type);
    public Task DeleteTypeAsync(TypeTrain type);
}