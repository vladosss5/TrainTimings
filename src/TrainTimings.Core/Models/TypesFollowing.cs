namespace TrainTimings.Core.Models;

public partial class TypesFollowing
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Time { get; set; }

    public virtual ICollection<CitiesTrain> CitiesTrains { get; set; } = new List<CitiesTrain>();
}
