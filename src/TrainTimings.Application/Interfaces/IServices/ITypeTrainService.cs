using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IServices;

public interface ITypeTrainService
{
    public Task<TypeTrain> GetTypeByIdAsync(int id);
    public Task<List<TypeTrain>> GetAllTypesAsync();
    public Task<TypeTrain> AddTypeAsync(TypeTrain type);
    public Task<TypeTrain> UpdateTypeAsync(TypeTrain type);
    public Task DeleteTypeAsync(int id);
}