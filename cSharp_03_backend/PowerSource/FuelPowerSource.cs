using System;

namespace cSharp_03_backend.PowerSource
{
    public class FuelPowerSource : PowerSource
    {
        private readonly e_FuelType fuelType;
        public enum e_FuelType { Soler, Octan95, Octan96, Octan98 };

        public FuelPowerSource(float maxEnergy, e_FuelType fuelType_d = e_FuelType.Octan95) : base(FuelPowerSource.e_EnergyType.Fuel, maxEnergy)
        {
            this.fuelType = fuelType_d;

        }




        public e_FuelType FuelType
        {
            get => (e_FuelType)this.fuelType;
        }


    }
}
