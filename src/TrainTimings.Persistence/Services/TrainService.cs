using TrainTimings.Application.Exceptions;
using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Persistence.Services;

public class TrainService : ITrainService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TrainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Train> GetByIdAsync(int id)
    {
        return await _unitOfWork.Train.GetTrainByIdAsync(id);
    }

    public async Task<Train> GetByNumberAsync(string number)
    {
        return await _unitOfWork.Train.GetTrainByNumberAsync(number);
    }

    public async Task<List<Train>> GetAllAsync()
    {
        return await _unitOfWork.Train.GetAllTrainsAsync();
    }

    public async Task<Train> CreateAsync(Train train)
    {
        var identity = await _unitOfWork.Train.GetTrainByNumberAsync(train.Number);
        if (identity != null)
            throw new AlreadyExistsException(nameof(Train), train.Number);

        var newTrain = new Train
        {
            Number = train.Number
        };
        
        var createdTrain = await _unitOfWork.Train.CreateTrainAsync(newTrain);
        
        return createdTrain;
    }

    public async Task<Train> UpdateAsync(Train train)
    {
        var updatingTrain = await _unitOfWork.Train.GetTrainByIdAsync(train.Id);
        if (updatingTrain == null)
            throw new NotFoundException(nameof(Train), train.Id);
        
        updatingTrain.Number = train.Number;
        
        var updatedTrain = await _unitOfWork.Train.UpdateTrainAsync(updatingTrain);
        
        return updatedTrain;
    }

    public async Task DeleteAsync(int id)
    {
        var deletingTrain = await _unitOfWork.Train.GetTrainByIdAsync(id);
        if (deletingTrain == null)
            throw new NotFoundException(nameof(Train), id);
        
        await _unitOfWork.Train.DeleteTrainAsync(deletingTrain);
    }
}