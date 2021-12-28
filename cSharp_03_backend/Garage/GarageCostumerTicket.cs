using System;
namespace cSharp_03_backend.Garage
{
    public class GarageCostumerTicket
    {
        public enum e_Vehicle_Status { Repairing, Repaired, Paid };
        private readonly string  costumerName;
        private readonly string phoneNumber;
        private e_Vehicle_Status vehicleStatus;
        Vehicles.Vehicle vehicle;


        public Vehicles.Vehicle Vehicle => vehicle;
        public e_Vehicle_Status VehicleStatus => vehicleStatus;
        public string PhoneNumber => phoneNumber;
        public string CostumerName => costumerName;



        public GarageCostumerTicket(string costumer_name , string phone_number , Vehicles.Vehicle client_vehicle)
        {
            this.costumerName = costumer_name;
            this.phoneNumber = phone_number;
            this.vehicle = client_vehicle;
            this.vehicleStatus = e_Vehicle_Status.Repairing;
        }

        public FullDetailReport GenerateFullDetailReport( )
        {

            FullDetailReport report = new FullDetailReport(this);
            return report;
        }


        public void  ChangeVehicleStatusInTheGarage(e_Vehicle_Status newStatus)
        {
            this.vehicleStatus = newStatus;
        }





    }
}
