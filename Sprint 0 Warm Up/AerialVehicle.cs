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
            if (CurrentAltitude == 0) {
                Engine.Stop();
            }
        }

        public string GetEngineStartedString() {
            string returnString = $"{Engine.GetType()} is ";
            returnString += Engine.IsStarted ? "": "not ";
            returnString += "started.";
            return returnString;
        }

        public string TakeOff()
        {
            if (Engine.IsStarted) {
                IsFlying = true;
                return $"{this.GetType()} is flying.";
            } else {
                return $"{this.GetType()} can't fly, its engine is not started.";
            }
        }

        public void FlyDown()
        {
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