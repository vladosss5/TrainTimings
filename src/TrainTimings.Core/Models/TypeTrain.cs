namespace TrainTimings.Core.Models;

public partial class TypeTrain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();
}
