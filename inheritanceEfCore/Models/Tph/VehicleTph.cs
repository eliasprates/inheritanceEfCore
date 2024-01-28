namespace inheritanceEfCore.Models.Tph
{
    public class VehicleTph
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        //Type is Motorcycle or Car
        public string Type { get; set; }
    }
}
