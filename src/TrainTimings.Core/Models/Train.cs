namespace TrainTimings.Core.Models;

public partial class Train
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual ICollection<CitiesTrain> CitiesTrains { get; set; } = new List<CitiesTrain>();

    public virtual ICollection<Timing> Timings { get; set; } = new List<Timing>();

    public virtual TypeTrain TypeTrain { get; set; } = null!;
}
