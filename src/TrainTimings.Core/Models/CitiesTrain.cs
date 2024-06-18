namespace TrainTimings.Core.Models;

public partial class CitiesTrain
{
    public int Id { get; set; }

    public int TrainId { get; set; }

    public int CityId { get; set; }

    public int TypeId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Train Train { get; set; } = null!;

    public virtual TypesFollowing Type { get; set; } = null!;
}
