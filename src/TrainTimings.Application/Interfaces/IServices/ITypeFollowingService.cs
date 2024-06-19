using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IServices;

public interface ITypeFollowingService
{
    public Task<TypesFollowing> GetAllTypesFollowing();
    public Task<TypesFollowing> GetTypesFollowingById(int id);
    public Task<TypesFollowing> AddTypesFollowing(TypesFollowing typesFollowing);
    public Task<TypesFollowing> UpdateTypesFollowing(TypesFollowing typesFollowing);
    public Task<TypesFollowing> DeleteTypesFollowing(int id);
}