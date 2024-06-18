using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Persistence.Data.Context;

namespace TrainTimings.Persistence.Helpers;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dbContext;
    
    private readonly ICityRepository _cityRepository;
    private readonly ICitiesTrainRepository _citiesTrainRepository;
    private readonly ITimingsRepository _timingsRepository;
    private readonly ITrainsRepository _trainsRepository;
    private readonly ITypesRepository _typesRepository;
    private readonly ITypesFollowingRepository _typesFollowingRepository;
    

    public UnitOfWork(DataContext dbContext, ICityRepository cityRepository, 
        ICitiesTrainRepository citiesTrainRepository, ITimingsRepository timingsRepository, 
        ITrainsRepository trainsRepository, ITypesRepository typesRepository, 
        ITypesFollowingRepository typesFollowingRepository)
    {
        _dbContext = dbContext;
        _cityRepository = cityRepository;
        _citiesTrainRepository = citiesTrainRepository;
        _timingsRepository = timingsRepository;
        _trainsRepository = trainsRepository;
        _typesRepository = typesRepository;
        _typesFollowingRepository = typesFollowingRepository;
    }

    public ICitiesTrainRepository CitiesTrain { get => _citiesTrainRepository; }
    public ICityRepository City { get => _cityRepository; }
    public ITimingsRepository Timing { get => _timingsRepository; }
    public ITrainsRepository Train { get => _trainsRepository; }
    public ITypesFollowingRepository TypeFollowing { get => _typesFollowingRepository; }
    public ITypesRepository Type { get => _typesRepository; }
}