using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Persistence.Services;

public class TypeFollowingService : ITypeFollowingService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TypeFollowingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TypesFollowing> GetAllTypesFollowing()
    {
        throw new NotImplementedException();
    }

    public async Task<TypesFollowing> GetTypesFollowingById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<TypesFollowing> AddTypesFollowing(TypesFollowing typesFollowing)
    {
        throw new NotImplementedException();
    }

    public async Task<TypesFollowing> UpdateTypesFollowing(TypesFollowing typesFollowing)
    {
        throw new NotImplementedException();
    }

    public async Task<TypesFollowing> DeleteTypesFollowing(int id)
    {
        throw new NotImplementedException();
    }
}