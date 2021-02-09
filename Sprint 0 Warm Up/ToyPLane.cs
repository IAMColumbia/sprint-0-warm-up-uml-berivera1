using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0_Warm_Up
{
    // Toy Plane is a child of the Airplane class.
    public class ToyPlane : Airplane
    {
        public bool IsWoundUp { get; set; }

        public ToyPlane() {
            // Toy Planes have a maximum altitude of 50 ft. We set this up in its constructor.
            MaxAltitude = 50;
        }

        public override string About() {
            // Toy Plane's About method also prints out the status of whether the vehicle's wound up, so it overrides the base About() method.
            string returnString = $"This {this.GetType()} has a max altitude of {MaxAltitude} ft.\n";
            returnString += $"Its current altitude is {CurrentAltitude} ft.\n";
            returnString += GetWindUpString() + "\n";
            returnString += GetEngineStartedString();
            return returnString;
        }

        public string GetWindUpString() {
            string returnString = $"{this.GetType()} is ";
            // This ternary operator checks whether the Toy Plane is wound up to return the correct status string.
            returnString += IsWoundUp ? "" : "not ";
            returnString += "wound up.";
            return returnString;
        }

        public override void StartEngine() {
            // Toy Plane must check if it is wound up before being able to start the engine.
            if (IsWoundUp) {
                base.StartEngine();
            }
        }

        public void UnWind() {
            IsWoundUp = false;
        }

        public void WindUp() {
            // NOTE TO SELF: As-is, the Toy Plane can be wound infinitely. Is there such a thing as winding it too much? Should we program that scenario, or stop the user from winding it up too much?
            IsWoundUp = true;
        }
    }
}
