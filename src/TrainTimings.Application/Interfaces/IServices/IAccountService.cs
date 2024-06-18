namespace TrainTimings.Application.Interfaces.IServices;

public interface IAccountService
{
    public Task<string> LoginAsync(string username, string password);
    public Task ChangePasswordAsync(string username, string oldPassword, string newPassword);
}