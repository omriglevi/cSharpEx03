using System;
using System.Collections.Generic;
using cSharp_03_backend.Vehicles;

namespace cSharp_03_backend.Garage
{
    public class Garage
    {
        List<GarageCostumerTicket> vehiclesInTheGarage=new List<GarageCostumerTicket>();



        public List<GarageCostumerTicket> GetListOfVehiclesInGarage => vehiclesInTheGarage;


        //change status in garage
        public void ChangeStatusInGarage(string i_licenceId , GarageCostumerTicket.e_Vehicle_Status i_Vehicle_Status)
        {
            GarageCostumerTicket ticket = GetTicket(i_licenceId);
            ticket?.ChangeVehicleStatusInTheGarage(i_Vehicle_Status);
            
        }

        //fill air
        public void fillAirInVehicle(string i_vehicleId)
        {
            GarageCostumerTicket ticket = GetTicket(i_vehicleId);
            ticket?.Vehicle.FillAirInWheelsSet();
        }

        // fill energy generic

        private void FillPowerSourceInVehicle<T>(string i_licenceId , float amountToAdd=0 , bool fillFullTank = false , PowerSource.FuelPowerSource.e_FuelType gasType=PowerSource.FuelPowerSource.e_FuelType.Octan95)
        {
           
            GarageCostumerTicket ticket= GetTicket(i_licenceId);
            PowerSource.PowerSource powerSource = ticket.Vehicle.energySource;
            if(amountToAdd + powerSource.EnergyLeft > powerSource.MaxEnergy)
            {
                throw new ArgumentException("sorry but you can not fill that much ");
            }
            if (ticket == null)
            {
                throw new ArgumentException("No such vehicle in the garage");

            }

            if(!(powerSource is T))
            {
                throw new ArgumentException("You can not fill this kind of powers source with the energy you chose");
            }

            if(powerSource is PowerSource.FuelPowerSource)
            {
              if ( gasType != ((PowerSource.FuelPowerSource)powerSource).FuelType)
                {
                    throw new ArgumentException("Gas Type Doesnt Match the powers source requirments");
                }

            }
            if (fillFullTank)
            {
                powerSource.EnergyLeft = powerSource.MaxEnergy;
                return;
            }

            powerSource.EnergyLeft += amountToAdd ;
        }

        

        //fill  electric ps
        public void FillElectricPowerSourceInVehicle(string i_licenceId , float amountToFill)
        {
          
                FillPowerSourceInVehicle<PowerSource.ElectricPowerSource>(i_licenceId , amountToFill);
        }
        
        //fill fuel ps
        public void FillFuelPowerSourceInVehicle(string i_licenceId ,  float amountToFill , PowerSource.FuelPowerSource.e_FuelType gasType)
        {
            FillPowerSourceInVehicle<PowerSource.FuelPowerSource>(i_licenceId, amountToFill);

        }

        // show full details

        public FullDetailReport GetVehicleFullDetails(string i_vehicleLicenceId)
        {
            GarageCostumerTicket ticket= GetTicket(i_vehicleLicenceId);
            if(ticket == null)
            {
                throw new ArgumentException("Vehicle is not in the garage");
            }
            return ticket.GenerateFullDetailReport();

        }

        // get full details by licence id




        public List<string> GetListOfVehiclesLicenceIDByStatus(GarageCostumerTicket.e_Vehicle_Status i_status=GarageCostumerTicket.e_Vehicle_Status.Repairing , bool doSort=true)
        {
            List<string> viechelsLicenceIdList = new List<string>();
            foreach(GarageCostumerTicket ticket in vehiclesInTheGarage)
            {
                if(ticket.VehicleStatus == i_status)
                {
                    viechelsLicenceIdList.Add(ticket.Vehicle.LicenceId);
                }
                else if (!doSort)
                {
                    viechelsLicenceIdList.Add(ticket.Vehicle.LicenceId);

                }

            }
            return  viechelsLicenceIdList;
        }


        public GarageCostumerTicket GetTicket(string i_vehicleId)
        {
            foreach(GarageCostumerTicket costumerTicket in vehiclesInTheGarage)
            {
                if(costumerTicket.Vehicle.LicenceId == i_vehicleId)
                {
                    return costumerTicket;
                }
            }
            return null;
        }

        private  Vehicle GetVehicle(string licence_id)
        {
            foreach(GarageCostumerTicket ticket in vehiclesInTheGarage)
            {
                Vehicle v = ticket.Vehicle;
                if(v.LicenceId == licence_id)
                {
                    return  v;
                }
            }
            return null;
        }


        private bool isTicketAlreadyInGarage(string licene_Id , bool changeStatus=false , GarageCostumerTicket.e_Vehicle_Status status =GarageCostumerTicket.e_Vehicle_Status.Repairing)
        {

            // checks all tickets
            foreach(GarageCostumerTicket ticket in vehiclesInTheGarage)
            {
                if(ticket.Vehicle.LicenceId == licene_Id)
                {

                    if (changeStatus)
                    {
                        Console.WriteLine("The vehicle is already in the garage");
                        ticket.ChangeVehicleStatusInTheGarage(status); 
                    }

                    return true;
                }
            }
            return false;
        }


        public void AddVehicle(Vehicle vehicle, string costumer_name, string costumer_phone)
        {
            string licence_vehicleId = vehicle.LicenceId;
            bool changeStatus = true;
            GarageCostumerTicket.e_Vehicle_Status newStatus = GarageCostumerTicket.e_Vehicle_Status.Repairing;
            if(!isTicketAlreadyInGarage(licence_vehicleId,changeStatus,newStatus ))
            {
                GarageCostumerTicket ticket = new GarageCostumerTicket(costumer_name, costumer_phone, vehicle);
                this.vehiclesInTheGarage.Add(ticket);
                return;
            }
            throw new ArgumentException("You Are trying to add a vehicle that is already exsited");

        }










    }
}
