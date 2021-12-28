using System;
namespace cSharp_03_backend.Garage
{
    public class FullDetailReport
    {

        private readonly string vehicleLicenceId;
        private readonly string modelName;
        private readonly string ownername;
        private readonly GarageCostumerTicket.e_Vehicle_Status vehicleStatusInTheGarage ;
        private readonly string wheelsBrand;
        private readonly float wheelRecPressure;
        private readonly string powerSrcType;
        private readonly float powerSrcEnergyLeftInPrecentage;


        public string VehicleLicenceId => vehicleLicenceId;
        public string ModelName => modelName;
        public string OwnerName => ownername;
        public string VehicleStatusInGarage => Enum.GetName(typeof(GarageCostumerTicket.e_Vehicle_Status), VehicleStatusInGarage);
        public string WheelsBrand => wheelsBrand;
        public float WheelRecPressure => wheelRecPressure;
        public string PowerSrcType => powerSrcType;
        public float PowerSrcEnergyLeftInPrecentage => powerSrcEnergyLeftInPrecentage;

        





        public FullDetailReport( GarageCostumerTicket vehicleGarageTicket )
        {
            Vehicles.Vehicle vehicle = vehicleGarageTicket.Vehicle;
            this.vehicleLicenceId = vehicle.LicenceId;
            this.modelName = vehicle.ModelName;
            this.ownername = vehicleGarageTicket.CostumerName;
            this.vehicleStatusInTheGarage = vehicleGarageTicket.VehicleStatus;
            this.wheelsBrand = vehicle.GetWheelsBrand();
            this.wheelRecPressure = vehicle.GetWheelsRecommendedPressure();
            this.powerSrcEnergyLeftInPrecentage = vehicle.GetPrecentageLeftInEnergySource();

            if(vehicle.energySource is PowerSource.FuelPowerSource)
            {
                this.powerSrcType = ((PowerSource.FuelPowerSource)vehicle.energySource).FuelType.ToString();
            }
            else
            {
                this.powerSrcType = vehicle.energySource.EnergyType.ToString();
            }
            




        }
    }
}
