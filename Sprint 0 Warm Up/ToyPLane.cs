using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0_Warm_Up
{
    class ToyPlane : Airplane
    {
        public bool IsWoundUp { get; set; }

        public ToyPlane() {
            MaxAltitude = 50;
        }

        public override string About() {
            string returnString = $"This {this.GetType()} has a max altitude of {MaxAltitude} ft.\n";
            returnString += $"Its current altitude is {CurrentAltitude} ft.\n";
            returnString += GetWindUpString();
            returnString += GetEngineStartedString();
            return returnString;
        }

        public string GetWindUpString() {
            string returnString = $"{this.GetType()} is ";
            returnString += IsWoundUp ? "" : "not ";
            returnString += "wound up.";
            return returnString;
        }

        public override void StartEngine() {
            if (IsWoundUp) {
                base.StartEngine();
            }
        }

        public void UnWind() {
            IsWoundUp = false;
        }

        public void WindUp() {
            IsWoundUp = true;
        }
    }
}
