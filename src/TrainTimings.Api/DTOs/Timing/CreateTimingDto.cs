namespace TrainTimings.Api.DTOs.Timing;

public class CreateTimingDto
{
    public DateTime Arrival { get; set; }

    public DateTime Departure { get; set; }

    public string Platform { get; set; } = null!;

    public int TrainId { get; set; }
}