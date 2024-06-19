using TrainTimings.Application.Exceptions;
using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Persistence.Services;

public class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<City>> GetAllAsync()
    {
        return await _unitOfWork.City.GetAllCitiesAsync();
    }

    public async Task<City> GetByIdAsync(int id)
    {
        return await _unitOfWork.City.GetCityByIdAsync(id);
    }

    public async Task<City> CreateAsync(City city)
    {
        var identity = await _unitOfWork.City.GetCityByNameAsync(city.Name);
        if (identity != null)
            throw new AlreadyExistsException(nameof(City), city.Name);

        var creatingCity = new City
        {
            Name = city.Name
        };
        
        var createdCity = await _unitOfWork.City.CreateCityAsync(creatingCity);
        
        return createdCity;
    }

    public async Task<City> UpdateAsync(City city)
    {
        var updatingCity = await _unitOfWork.City.GetCityByIdAsync(city.Id);
        if (updatingCity == null)
            throw new NotFoundException(nameof(City), city.Id);
        
        updatingCity.Name = city.Name;
        
        var updatedCity = await _unitOfWork.City.UpdateCityAsync(updatingCity);
        
        return updatedCity;
    }

    public async Task DeleteAsync(int id)
    {
        var deletingCity = await _unitOfWork.City.GetCityByIdAsync(id);
        if (deletingCity == null)
            throw new NotFoundException(nameof(City), id);
        
        await _unitOfWork.City.DeleteCityAsync(deletingCity);
    }
}