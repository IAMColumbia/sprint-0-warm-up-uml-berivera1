using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

// Note: Test code modified from test files within the provided UnitTestProjectAV folder.

namespace UnitTestsForSprint0 {
    [TestClass]
    public class HelicopterTests {
        private Helicopter helicopter;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public Helicopter Helicopter { get { return helicopter; } set { helicopter = value; } }

        public HelicopterTests() {
            Helicopter = new Helicopter();
        }

        [TestMethod]
        public void HelicopterAbout() {
            //Arrange 
            Helicopter hc = this.Helicopter;
            //Act
            // Nothing to act on here.
            //Assert
            Assert.AreEqual(hc.About(), $"This {hc.ToString()} has a max altitude of 8000 ft.\nIts current altitude is 0 ft.\n{hc.Engine.ToString()} is not started.");
        }

        [TestMethod]
        public void HelicopterEngine() {
            //Arrange
            Helicopter hc = this.Helicopter;
            //Act 
            bool defaultEngine = hc.Engine.IsStarted;  //default should be off
            hc.StartEngine();
            bool startedEngine = hc.Engine.IsStarted;
            hc.StopEngine();
            bool stoppedEngine = hc.Engine.IsStarted;
            //Assert
            Assert.AreEqual(defaultEngine, false); // default is stopped
            Assert.AreEqual(startedEngine, true); // after start is called engine should be stated
            Assert.AreEqual(stoppedEngine, false); // after stop is called engine should be stopped
        }

        [TestMethod]
        public void HelicopterTakeOff() {
            //Arrange 
            Helicopter hc = this.Helicopter;
            //act
            string firstTakeoff = hc.TakeOff();
            bool engineBeforeStart = hc.Engine.IsStarted;
            hc.StartEngine();
            string secondTakeOff = hc.TakeOff();
            //Assert
            Assert.AreEqual(firstTakeoff, hc.ToString() + " can't fly, its engine is not started.");
            Assert.AreEqual(secondTakeOff, hc.ToString() + " is flying.");
            Assert.AreEqual(engineBeforeStart, false);
            Assert.AreEqual(hc.Engine.IsStarted, true);
        }

        [TestMethod]
        public void HelicopterFlyUp() {
            //Arrange 
            Helicopter hc = this.Helicopter;
            //act
            hc.StartEngine();
            string firstTakeoff = hc.TakeOff();
            int defaultHeight = hc.CurrentAltitude;
            hc.FlyUp();
            int firstAlt = hc.CurrentAltitude;
            hc.FlyUp(7000);
            int secondAlt = hc.CurrentAltitude;
            hc.FlyUp(1); // This should fail and return the same value as the previous.
            int thirdAlt = hc.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(firstAlt, 1000);
            Assert.AreEqual(secondAlt, 8000);
            Assert.AreEqual(thirdAlt, secondAlt);

        }

        [TestMethod]
        public void HelicopterFlyDown() {
            //Arrange 
            Helicopter hc = this.Helicopter;
            //act
            hc.StartEngine();
            string firstTakeoff = hc.TakeOff();
            int defaultHeight = hc.CurrentAltitude;
            hc.FlyDown();
            //test is flying again
            int FlyDown = hc.CurrentAltitude;
            hc.TakeOff();
            hc.FlyDown(1);
            //test is flying again
            hc.TakeOff();
            int FlyDownOneAlreadyZero = hc.CurrentAltitude;
            hc.FlyUp(2);
            hc.FlyDown(1);
            int FlyDownOneAtTwo = hc.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(FlyDown, 0);
            Assert.AreEqual(FlyDownOneAlreadyZero, 0);
            Assert.AreEqual(FlyDownOneAtTwo, 1);
        }
    }
}
