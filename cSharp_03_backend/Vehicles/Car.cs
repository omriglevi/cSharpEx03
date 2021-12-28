using System.Collections.Generic;
using cSharp_03_backend.Wheels;

namespace cSharp_03_backend.Vehicles
{


    public class Car : Vehicle


    {
        private int numberOfDoors;
        public enum e_Color { Red, Blue, Yellow, Green, White, Left };
        e_Color color;

        public int NumberOfDoors
        {
            get => numberOfDoors;
        }

        public e_Color Color
        {
            get => (e_Color)color;
        }

        public Car(PowerSource.PowerSource energySrc, string licence_id, string model, List<Wheel> wheels, e_Color color, int number_of_doors) : base(energySrc, licence_id, model, wheels)
        {
            this.numberOfDoors = number_of_doors;
            this.color = color;

        }
    }
}
