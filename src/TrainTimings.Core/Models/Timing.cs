namespace TrainTimings.Core.Models;

public partial class Timing
{
    public int Id { get; set; }

    public DateTime Arrival { get; set; }

    public DateTime Departure { get; set; }

    public string Platform { get; set; } = null!;

    public int TrainId { get; set; }

    public virtual Train Train { get; set; } = null!;
}
