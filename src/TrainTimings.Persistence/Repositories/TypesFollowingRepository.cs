using Microsoft.EntityFrameworkCore;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Core.Models;
using TrainTimings.Persistence.Data.Context;

namespace TrainTimings.Persistence.Repositories;

public class TypesFollowingRepository : ITypesFollowingRepository
{
    private readonly DataContext _dataContext;
    
    public TypesFollowingRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TypesFollowing> GetTypesFollowingByIdAsync(int id)
    {
        return await _dataContext.TypesFollowings.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TypesFollowing>> GetAllTypesFollowingAsync()
    {
        return await _dataContext.TypesFollowings.ToListAsync();
    }

    public async Task<TypesFollowing> CreateTypesFollowingAsync(TypesFollowing typesFollowing)
    {
        await _dataContext.TypesFollowings.AddAsync(typesFollowing);
        await _dataContext.SaveChangesAsync();
        
        return typesFollowing;
    }

    public async Task<TypesFollowing> UpdateTypesFollowingAsync(TypesFollowing typesFollowing)
    {
        _dataContext.TypesFollowings.Update(typesFollowing);
        await _dataContext.SaveChangesAsync();
        
        return typesFollowing;
    }

    public async Task DeleteTypesFollowingAsync(TypesFollowing typesFollowing)
    {
        _dataContext.TypesFollowings.Remove(typesFollowing);
        await _dataContext.SaveChangesAsync();
    }
}