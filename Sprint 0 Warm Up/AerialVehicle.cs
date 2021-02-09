using System;
using static System.Console;

namespace Sprint_0_Warm_Up
{
    public abstract class AerialVehicle
    {
        public int CurrentAltitude { get; set; }
        Engine Engine { get; set; }
        public bool IsFlying { get; set; }
        public int MaxAltitude { get; set; }

        public AerialVehicle()
        {
            Engine = new Engine();
        }

        public virtual string About()
        {
            string returnString = $"This {this.GetType()} has a max altitude of {MaxAltitude} ft.\n";
            returnString += $"Its current altitude is {CurrentAltitude} ft.\n";
            returnString += GetEngineStartedString();
            return returnString;
        }

        public virtual void StartEngine()
        {
            Engine.Start();
        }

        public void StopEngine() {
            // The user cannot stop the engine unless the vehicle is on the ground. This is to prevent theorhetical distasters of people shutting of the engine mid-flight.
            if (CurrentAltitude == 0) {
                Engine.Stop();
                // NOTE TO SELF: Currently, the vehicle is considered not flying once StopEngine is called and its on the ground. Should this automatically be true when the vehicle hits the ground (using a conditional statement in the FlyDown() method)?
                IsFlying = false;
            }
        }

        public string GetEngineStartedString() {
            string returnString = $"{Engine.GetType()} is ";
            // This ternary operator checks whether the vehicle's engine is on to return the correct status string.
            returnString += Engine.IsStarted ? "": "not ";
            returnString += "started.";
            return returnString;
        }

        public string TakeOff()
        {
            // Tne vehicle cannot take off unless its engine is started beforehand.
            if (Engine.IsStarted) {
                IsFlying = true;
                return $"{this.GetType()} is flying.";
            } else {
                return $"{this.GetType()} can't fly, its engine is not started.";
            }
        }

        public void FlyDown()
        {
            // The vehicle cannot fly up/down unless it is already flying.
            if (IsFlying) {
                if (CurrentAltitude - 1000 >= 0) {
                    CurrentAltitude -= 1000;
                }
            }
        }

        public void FlyDown(int howMuch)
        {
            if (IsFlying) {
                if (CurrentAltitude - howMuch >= 0) {
                    CurrentAltitude -= howMuch;
                }
            }
        }

        public void FlyUp()
        {
            if (IsFlying) {
                if (CurrentAltitude + 1000 <= MaxAltitude) {
                    CurrentAltitude += 1000;
                }
            }
        }

        public void FlyUp(int howMuch)
        {
            if (IsFlying) {
                if (CurrentAltitude + howMuch <= MaxAltitude) {
                    CurrentAltitude += howMuch;
                }
            }
        }
    }
}