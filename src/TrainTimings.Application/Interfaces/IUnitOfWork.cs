using TrainTimings.Application.Interfaces.IRepository;

namespace TrainTimings.Application.Interfaces;

public interface IUnitOfWork
{
    public ICitiesTrainRepository CitiesTrain { get; }
    public ICityRepository City { get; }
    public ITimingsRepository Timing { get; }
    public ITrainsRepository Train { get; }
    public ITypesFollowingRepository TypeFollowing { get; }
    public ITypesRepository Type { get; }
}