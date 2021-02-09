using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0_Warm_Up {
    class Airport {
        // The amount of vehicles that are allowed in the Airport. Default to 1, but can be defined with the second constructor (line 14).
        private int MaxVehicles = 1;
        private List<AerialVehicle> Vehicles = new List<AerialVehicle>();
        public string AirportCode { get; set; }
        public Airport(string Code) {
            AirportCode = Code;
        }
        public Airport(string Code, int MaxVehicles) {
            AirportCode = Code;
            this.MaxVehicles = MaxVehicles;
        }
        public string AllTakeOff() {
            // NOTE TO SELF: After vehicles take off, they stay at altitude of 0. Does this make sense? Should the AerialVehicle TakeOff() method bring it up into the air a bit, maybe something like 10% of the vehicle's max altitude?
            string returnString = "";
            for (int i = 0; i < Vehicles.Count; i++) {
                Vehicles[i].StartEngine();
                returnString += Vehicles[i].TakeOff() + "\n";
            }
            Vehicles.Clear();
            return returnString;
        }
        public string Land(AerialVehicle a) {
            // Check if there's room for the Aerial Vehicle to land, then add it to the Airport's Vehicles if there is room.
            if (Vehicles.Count < MaxVehicles) {
                a.FlyDown(a.CurrentAltitude);
                a.IsFlying = false;
                Vehicles.Add(a);
                return $"{a.GetType()} has landed successfully.";
            }
            return "The airport is currently full, and cannot accomidate any more aerial vehicles.";
        }
        public string Land(List<AerialVehicle> landing) {
            string returnString = "";
            // Iterate through all vehicles in the landing parameter. Allow them to land if they can, and return an error string if they cannot.
            for (int i = 0; i < landing.Count; i++) {
                if (Vehicles.Count < MaxVehicles) {
                    landing[i].FlyDown(landing[i].CurrentAltitude);
                    landing[i].IsFlying = false;
                    Vehicles.Add(landing[i]);
                    returnString += $"{landing[i].GetType()} has landed successfully.\n";
                }
                returnString += $"The airport is currently full, and cannot accomidate aerial vehicle #{i} that tried to land.\n";
            }
            return returnString;
        }
        public string TakeOff(AerialVehicle a) {
            // NOTE TO SELF: This just lets a random Aerial Vehicle take off. Should there be a prerequesite that the vehicle itself was inside of the Airport (existed within its Vehicles List)? Or are these theorhetical random planes that are coming in and immediately taking off again?
            a.StartEngine();
            return a.TakeOff();
        }
    }
}
