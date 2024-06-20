using TrainTimings.Application.Exceptions;
using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Persistence.Services;

public class TypeTrainService : ITypeTrainService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TypeTrainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TypeTrain> GetTypeByIdAsync(int id)
    {
        var type = await _unitOfWork.Type.GetTypeByIdAsync(id);
        if (type == null)
            throw new NotFoundException(nameof(TypeTrain), id);
        
        return type;
    }

    public async Task<List<TypeTrain>> GetAllTypesAsync()
    {
        return await _unitOfWork.Type.GetAllTypesAsync();
    }

    public async Task<TypeTrain> AddTypeAsync(TypeTrain type)
    {
        var newType = await _unitOfWork.Type.CreateTypeAsync(type);

        return newType;
    }

    public async Task<TypeTrain> UpdateTypeAsync(TypeTrain type)
    {
        var updatingType = await _unitOfWork.Type.GetTypeByIdAsync(type.Id);
        if (updatingType == null)
            throw new NotFoundException(nameof(TypeTrain), type.Id);
        
        var updatedType = await _unitOfWork.Type.UpdateTypeAsync(type);
        return updatedType;
    }

    public async Task DeleteTypeAsync(int id)
    {
        var type = await _unitOfWork.Type.GetTypeByIdAsync(id);
        if (type == null)
            throw new NotFoundException(nameof(TypeTrain), id);
        
        await _unitOfWork.Type.DeleteTypeAsync(type);
    }
}