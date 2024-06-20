namespace TrainTimings.Api.DTOs.TypeFollowing;

public class UpdateTypeFollowingDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Time { get; set; }
}