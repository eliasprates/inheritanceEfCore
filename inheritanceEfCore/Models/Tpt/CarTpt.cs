using System.ComponentModel.DataAnnotations.Schema;

namespace inheritanceEfCore.Models.Tpt
{
    public class CarTpt : VehicleTpt
    {
        public int NumberOfDoors { get; set; }
        [ForeignKey("VehicleTpt")]
        public int VehicleId { get; set; }
        public VehicleTpt VehicleTpt { get; set; }
    }
}
