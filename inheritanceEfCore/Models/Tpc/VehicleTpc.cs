namespace inheritanceEfCore.Models.Tpc
{
    public abstract class VehicleTpc
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
    }
}
