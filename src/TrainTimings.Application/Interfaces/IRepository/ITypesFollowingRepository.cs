using TrainTimings.Core.Models;

namespace TrainTimings.Application.Interfaces.IRepository;

public interface ITypesFollowingRepository
{
    public Task<TypesFollowing> GetTypesFollowingByIdAsync(int id);
    public Task<List<TypesFollowing>> GetAllTypesFollowingAsync();
    public Task<TypesFollowing> CreateTypesFollowingAsync(TypesFollowing typesFollowing);
    public Task<TypesFollowing> UpdateTypesFollowingAsync(TypesFollowing typesFollowing);
    public Task DeleteTypesFollowingAsync(TypesFollowing typesFollowing);
}