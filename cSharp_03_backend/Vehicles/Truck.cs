using System.Collections.Generic;
using cSharp_03_backend.Wheels;




namespace cSharp_03_backend.Vehicles
{
    public class Truck : Vehicle
    {
        private bool isCooling;
        private float cargoVol;


        public Truck( PowerSource.PowerSource energySrc, string licence_id, string model, List<Wheel> wheels, bool is_cooling, float cargo_vol) : base(energySrc, licence_id, model, wheels)
        {
            this.isCooling = is_cooling;
            this.cargoVol = cargo_vol;
        }


    }
}
