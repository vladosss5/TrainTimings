namespace TrainTimings.Core.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CitiesTrain> CitiesTrains { get; set; } = new List<CitiesTrain>();
}
