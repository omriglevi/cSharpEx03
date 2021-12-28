using System.Collections.Generic;
using cSharp_03_backend.Wheels;
using cSharp_03_backend.PowerSource;


namespace cSharp_03_backend.Vehicles

{
    public class Vehicle
    {
        //PowerSource.PowerSource.e_EnergyType energyType;
        public PowerSource.PowerSource energySource;
        private readonly string licencId;
        private readonly string modelName;
        private List<Wheel> wheels = new List<Wheel>();
        public string LicenceId =>  licencId;
        public string ModelName => modelName;


        public string GetWheelsBrand()
        {
            if(this.wheels.Count <1 )
            {
                return null;
            }
            return wheels[0].Brand;
        }

        public float GetHowMuchEnergyPossibleToFill()
        {
            return(energySource.MaxEnergy -energySource.EnergyLeft);
        }

        public float GetWheelsRecommendedPressure()
        {
            if(wheels.Count <1)
            {
                return 0;
            }
            return this.wheels[0].RecommendedPressure;
            
        }


        public void FillAirInWheelsSet()
        {
            foreach(Wheel w in wheels)
            {
                w.FillAir();
            }
        }

        public float GetPrecentageLeftInEnergySource()
        {
            return (this.energySource.EnergyLeft / energySource.MaxEnergy) * 100 ;
        }

        public void AddSetOfWheels(List<Wheel> wheels_list)
        {
            foreach (Wheel w in wheels_list)
            {
                Wheel tempWheel = new Wheel(w.Brand, w.RecommendedPressure);
                wheels.Add(tempWheel);

            }
        }
        public void AddPowerSource(PowerSource.PowerSource energy_source)
        {
            PowerSource.PowerSource tempEnergySrc;
            if (energy_source is PowerSource.FuelPowerSource)
            {
                tempEnergySrc = new FuelPowerSource(energy_source.MaxEnergy, ((FuelPowerSource)energy_source).FuelType);
                this.energySource = tempEnergySrc;
            }
            else
            {
                tempEnergySrc = new ElectricPowerSource(energy_source.MaxEnergy);
                this.energySource = tempEnergySrc;


            }
        }


        protected Vehicle(PowerSource.PowerSource energy_src, string licence_Id, string model_name, List<Wheel> wheels_list)
        {

            this.licencId = licence_Id;
            this.modelName = model_name;
            this.energySource = energy_src;
            AddSetOfWheels(wheels_list);
            AddPowerSource(energy_src);


        }


    }
}
