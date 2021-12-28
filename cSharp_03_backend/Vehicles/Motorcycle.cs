
using System.Collections.Generic;
using System;
using cSharp_03_backend.Wheels;

namespace cSharp_03_backend.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public enum e_LicenceType { A, A2, AA, B }
        float engineVol;
        e_LicenceType licenceType;


        public e_LicenceType LicenceType
        {
            get => (e_LicenceType)engineVol;
        }

        public float EngineVolume
        {
            get => engineVol;

        }


        public Motorcycle(PowerSource.PowerSource energySrc, string licence_id, string model, List<Wheel> wheels, e_LicenceType licence_type, float engine_vol) : base(energySrc, licence_id, model, wheels)
        {
            if(wheels.Count != 2 )
            {
                throw new ArgumentException("Motorcycle must have 2 Wheels only ");
            }
            this.engineVol = engine_vol;
            this.licenceType = licence_type;
        }
    }
}
