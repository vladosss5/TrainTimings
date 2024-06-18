using TrainTimings.Application.Exceptions;
using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Persistence.Services;

public class TiminggService : ITiminggService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TiminggService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Timing> CreateTimingAsync(Timing timing)
    {
        var train = await _unitOfWork.Train.GetTrainByIdAsync(timing.TrainId);
        if (train == null)
            throw new NotFoundException(nameof(Train), timing.TrainId);

        var createdTiming = await _unitOfWork.Timing.CreateTimingAsync(timing);
        
        return createdTiming;
    }

    public async Task<Timing> UpdateTimingAsync(Timing timing)
    {
        var train = await _unitOfWork.Train.GetTrainByIdAsync(timing.TrainId);
        if (train == null)
            throw new NotFoundException(nameof(Train), timing.TrainId);

        var timingToUpdate = await _unitOfWork.Timing.GetTimingByIdAsync(timing.Id);
        if (timingToUpdate == null)
            throw new NotFoundException(nameof(Timing), timing.Id);

        timingToUpdate.Arrival = timing.Arrival;
        timingToUpdate.Departure = timing.Departure;
        
        var updatedTiming = await _unitOfWork.Timing.UpdateTimingAsync(timingToUpdate);
        
        return updatedTiming;
    }

    public async Task<Timing> GetTimingByIdAsync(int id)
    {
        var timing = await _unitOfWork.Timing.GetTimingByIdAsync(id);
        if (timing == null)
            throw new NotFoundException(nameof(Timing), id);
        
        return timing;
    }

    public async Task<List<Timing>> GetAllTimingsAsync()
    {
        return await _unitOfWork.Timing.GetAllTimingsAsync();
    }

    public async Task DeleteTimingAsync(int id)
    {
        var timing = await _unitOfWork.Timing.GetTimingByIdAsync(id);
        if (timing == null)
            throw new NotFoundException(nameof(Timing), id);
        
        await _unitOfWork.Timing.DeleteTimingAsync(timing);
    }
}