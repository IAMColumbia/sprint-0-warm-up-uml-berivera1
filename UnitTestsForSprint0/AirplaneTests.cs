using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

// Note: Test code modified from test files within the provided UnitTestProjectAV folder.

namespace UnitTestsForSprint0 {
    [TestClass]
    public class AirplaneTests {
        private Airplane airplane;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public Airplane Airplane { get { return airplane; } set { airplane = value; } }

        public AirplaneTests() {
            Airplane = new Airplane();
        }

        [TestMethod]
        public void AirplaneAbout() {
            //Arrange 
            Airplane ap = this.Airplane;
            //Act
            // Nothing to act on here.
            //Assert
            Assert.AreEqual(ap.About(), $"This {ap.ToString()} has a max altitude of 41000 ft.\nIts current altitude is 0 ft.\n{ap.Engine.ToString()} is not started.");
        }

        [TestMethod]
        public void AirplaneEngine() {
            //Arrange
            Airplane ap = this.Airplane;
            //Act 
            bool defaultEngine = ap.Engine.IsStarted;  //default should be off
            ap.StartEngine();
            bool startedEngine = ap.Engine.IsStarted;
            ap.StopEngine();
            bool stoppedEngine = ap.Engine.IsStarted;
            //Assert
            Assert.AreEqual(defaultEngine, false); // default is stopped
            Assert.AreEqual(startedEngine, true); // after start is called engine should be stated
            Assert.AreEqual(stoppedEngine, false); // after stop is called engine should be stopped
        }

        [TestMethod]
        public void AirplaneTakeOff() {
            //Arrange 
            Airplane ap = this.Airplane;
            //act
            string firstTakeoff = ap.TakeOff();
            bool engineBeforeStart = ap.Engine.IsStarted;
            ap.StartEngine();
            string secondTakeOff = ap.TakeOff();
            //Assert
            Assert.AreEqual(firstTakeoff, ap.ToString() + " can't fly, its engine is not started.");
            Assert.AreEqual(secondTakeOff, ap.ToString() + " is flying.");
            Assert.AreEqual(engineBeforeStart, false);
            Assert.AreEqual(ap.Engine.IsStarted, true);
        }

        [TestMethod]
        public void AirplaneFlyUp() {
            //Arrange 
            Airplane ap = this.Airplane;
            //act
            ap.StartEngine();
            string firstTakeoff = ap.TakeOff();
            int defaultHeight = ap.CurrentAltitude;
            ap.FlyUp();
            int firstAlt = ap.CurrentAltitude;
            ap.FlyUp(40000);
            int secondAlt = ap.CurrentAltitude;
            ap.FlyUp(1); // This should fail and return the same value as the previous.
            int thirdAlt = ap.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(firstAlt, 1000);
            Assert.AreEqual(secondAlt, 41000);
            Assert.AreEqual(thirdAlt, secondAlt);

        }

        [TestMethod]
        public void AirplaneFlyDown() {
            //Arrange 
            Airplane ap = this.Airplane;
            //act
            ap.StartEngine();
            string firstTakeoff = ap.TakeOff();
            int defaultHeight = ap.CurrentAltitude;
            ap.FlyDown();
            //test is flying again
            int FlyDown = ap.CurrentAltitude;
            ap.TakeOff();
            ap.FlyDown(1);
            //test is flying again
            ap.TakeOff();
            int FlyDownOneAlreadyZero = ap.CurrentAltitude;
            ap.FlyUp(2);
            ap.FlyDown(1);
            int FlyDownOneAtTwo = ap.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(FlyDown, 0);
            Assert.AreEqual(FlyDownOneAlreadyZero, 0);
            Assert.AreEqual(FlyDownOneAtTwo, 1);
        }
    }
}
