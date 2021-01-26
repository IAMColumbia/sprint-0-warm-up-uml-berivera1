using System;

namespace Sprint_0_Warm_Up
{
    public abstract class AerialVehicle
    {
        public int CurrentAltitude { get; set; }

        Engine Engine { get; set; }

        public AerialVehicle()
        {

        }

        public bool About()
        {
            throw new NotImplementedException();
        }

        public bool TakeOff()
        {
            throw new NotImplementedException();
        }

        public void StartEngine()
        {
            throw new NotImplementedException();
        }

        public void FlyDown(int howMuch)
        {
            throw new NotImplementedException();
        }

        internal void FlyUp()
        {
            throw new NotImplementedException();
        }

        internal void FlyUp(int HowMuch)
        {
            throw new NotImplementedException();
        }
    }
}