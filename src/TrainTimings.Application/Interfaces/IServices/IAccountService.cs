namespace TrainTimings.Application.Interfaces.IServices;

public interface IAccountService
{
    public Task<string> LoginAsync(string username, string password);
}