namespace TrainTimings.Api.DTOs.Account;

public class ChangePasswordDto
{
    public string Username { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}