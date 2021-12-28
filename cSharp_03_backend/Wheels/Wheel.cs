using System;
namespace cSharp_03_backend.Wheels
{
    public class Wheel
    {
        private readonly string brand;
        float current_pressure;
        float recommended_pressure;

        public string Brand
        {
            get => brand;
        }

        public float CurrentPressur
        {
            get => current_pressure;
            set => current_pressure = value;
        }

        public float RecommendedPressure
        {
            get => recommended_pressure;
            set => recommended_pressure = value;
        }

        public void FillAir()
        {
            this.current_pressure = recommended_pressure;
        }


        public Wheel(string wheel_brand, float recomended_pressure)
        {
            this.brand = wheel_brand;
            this.recommended_pressure = recomended_pressure;
            this.current_pressure = recomended_pressure;
        }

        public Wheel(string wheel_brand, float recomended_pressure, float current_pressure)
        {
            this.brand = wheel_brand;
            this.recommended_pressure = recomended_pressure;
            this.current_pressure = current_pressure;
        }

    }
}
