using System;
namespace cSharp_03_backend.PowerSource
{
    public class PowerSource
    {

        public enum e_EnergyType { Fuel, Electric }


        private e_EnergyType _energyType;
        private float _energyLeft ;
        private float _maxEnergy;


        public float EnergyLeft
        {
            get => _energyLeft;
            set => _energyLeft = value;
        }

        public e_EnergyType EnergyType
        {
            get => _energyType;
            //set => _energyType = value;
        }
        public float MaxEnergy
        {
            get => _maxEnergy;
            set => _maxEnergy = value;
        }









        public PowerSource(e_EnergyType energyType, float maxEnergy)
        {
            this._energyType = energyType;
            this._maxEnergy = maxEnergy;
            this._energyLeft = maxEnergy;

        }

        public PowerSource(e_EnergyType energyType, float maxEnergy, float energyLeft)
        {
            this._energyType = energyType;
            this._maxEnergy = maxEnergy;
            this._energyLeft = energyLeft;
        }
    }



}
