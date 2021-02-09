using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_0_Warm_Up {
    public class Drone : AerialVehicle {
        public Drone() {
            // Drones have a maximum altitude of 500 ft. We set this up in its constructor.
            MaxAltitude = 500;
        }
    }
}
