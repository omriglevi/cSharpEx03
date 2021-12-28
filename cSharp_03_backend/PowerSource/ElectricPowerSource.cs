using System;
namespace cSharp_03_backend.PowerSource
{
    public class ElectricPowerSource : PowerSource
    {
        public ElectricPowerSource(float maxEnergy) : base(PowerSource.e_EnergyType.Electric, maxEnergy)
        {
        }
    }
}
