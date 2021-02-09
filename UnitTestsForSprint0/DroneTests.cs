using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

// Note: Test code modified from test files within the provided UnitTestProjectAV folder.

namespace UnitTestsForSprint0 {
    [TestClass]
    public class DroneTests {
        private Drone drone;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public Drone Drone { get { return drone; } set { drone = value; } }

        public DroneTests() {
            Drone = new Drone();
        }

        [TestMethod]
        public void DroneAbout() {
            //Arrange 
            Drone dr = this.Drone;
            //Act
            // Nothing to act on here.
            //Assert
            Assert.AreEqual(dr.About(), $"This {dr.ToString()} has a max altitude of 500 ft.\nIts current altitude is 0 ft.\n{dr.Engine.ToString()} is not started.");
        }

        [TestMethod]
        public void DroneEngine() {
            //Arrange
            Drone dr = this.Drone;
            //Act 
            bool defaultEngine = dr.Engine.IsStarted;  //default should be off
            dr.StartEngine();
            bool startedEngine = dr.Engine.IsStarted;
            dr.StopEngine();
            bool stoppedEngine = dr.Engine.IsStarted;
            //Assert
            Assert.AreEqual(defaultEngine, false); // default is stopped
            Assert.AreEqual(startedEngine, true); // after start is called engine should be stated
            Assert.AreEqual(stoppedEngine, false); // after stop is called engine should be stopped
        }

        [TestMethod]
        public void DroneTakeOff() {
            //Arrange 
            Drone dr = this.Drone;
            //act
            string firstTakeoff = dr.TakeOff();
            bool engineBeforeStart = dr.Engine.IsStarted;
            dr.StartEngine();
            string secondTakeOff = dr.TakeOff();
            //Assert
            Assert.AreEqual(firstTakeoff, dr.ToString() + " can't fly, its engine is not started.");
            Assert.AreEqual(secondTakeOff, dr.ToString() + " is flying.");
            Assert.AreEqual(engineBeforeStart, false);
            Assert.AreEqual(dr.Engine.IsStarted, true);
        }

        [TestMethod]
        public void DroneFlyUp() {
            //Arrange 
            Drone dr = this.Drone;
            //act
            dr.StartEngine();
            string firstTakeoff = dr.TakeOff();
            int defaultHeight = dr.CurrentAltitude;
            dr.FlyUp(); // This should fail, because the AerialVehicle's FlyUp() goes up 1000 ft, while the Drone has a maximum altitude of 500 ft.
            int firstAlt = dr.CurrentAltitude;
            dr.FlyUp(500);
            int secondAlt = dr.CurrentAltitude;
            dr.FlyUp(1); // This should fail and return the same value as the previous.
            int thirdAlt = dr.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(firstAlt, 0);
            Assert.AreEqual(secondAlt, 500);
            Assert.AreEqual(thirdAlt, secondAlt);

        }

        [TestMethod]
        public void DroneFlyDown() {
            //Arrange 
            Drone dr = this.Drone;
            //act
            dr.StartEngine();
            string firstTakeoff = dr.TakeOff();
            int defaultHeight = dr.CurrentAltitude;
            dr.FlyDown();
            //test is flying again
            int FlyDown = dr.CurrentAltitude;
            dr.TakeOff();
            dr.FlyDown(1);
            //test is flying again
            dr.TakeOff();
            int FlyDownOneAlreadyZero = dr.CurrentAltitude;
            dr.FlyUp(2);
            dr.FlyDown(1);
            int FlyDownOneAtTwo = dr.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(FlyDown, 0);
            Assert.AreEqual(FlyDownOneAlreadyZero, 0);
            Assert.AreEqual(FlyDownOneAtTwo, 1);
        }
    }
}
