namespace TrainTimings.Api.DTOs.TypeFollowing;

public class CreateTypeFollowingDto
{
    public string Name { get; set; } = null!;

    public DateTime Time { get; set; }
}