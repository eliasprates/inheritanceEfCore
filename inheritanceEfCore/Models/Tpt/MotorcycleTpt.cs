using System.ComponentModel.DataAnnotations.Schema;

namespace inheritanceEfCore.Models.Tpt
{
    public class MotorcycleTpt : VehicleTpt
    {
        public bool HasFairing { get; set; }
        [ForeignKey("VehicleTpt")]
        public int VehicleId { get; set; }
        public VehicleTpt VehicleTpt { get; set; }
    }
}
