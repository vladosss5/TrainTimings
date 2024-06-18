using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IRepository;

public interface ICitiesTrainRepository
{
    public Task<CitiesTrain> GetCitiesTrainByIdAsync(int id);
    public Task<List<CitiesTrain>> GetAllCitiesTrainsAsync();
    public Task<CitiesTrain> CreateCitiesTrainAsync(CitiesTrain citiesTrain);
    public Task<CitiesTrain> UpdateCitiesTrainAsync(CitiesTrain citiesTrain);
    public Task DeleteCitiesTrainAsync(CitiesTrain citiesTrain);
}