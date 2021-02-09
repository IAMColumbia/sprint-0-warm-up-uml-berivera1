using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

// Note: Test code modified from test files within the provided UnitTestProjectAV folder.

namespace UnitTestsForSprint0 {
    [TestClass]
    public class ToyPlaneTests {
        private ToyPlane toyPlane;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public ToyPlane ToyPlane { get { return toyPlane; } set { toyPlane = value; } }

        public ToyPlaneTests() {
            ToyPlane = new ToyPlane();
        }

        [TestMethod]
        public void ToyPlaneAbout() {
            //Arrange 
            ToyPlane tp = this.ToyPlane;
            //Act
            // Nothing to act on here.
            //Assert
            Assert.AreEqual(tp.About(), $"This {tp.ToString()} has a max altitude of 50 ft.\nIts current altitude is 0 ft.\n{tp.ToString()} is not wound up.\n{tp.Engine.ToString()} is not started.");
        }

        [TestMethod]
        public void ToyPlaneEngine() {
            //Arrange
            ToyPlane tp = this.ToyPlane;
            //Act 
            bool defaultEngine = tp.Engine.IsStarted;  //default should be off
            tp.StartEngine();
            bool startedEngineBeforeWind = tp.Engine.IsStarted; // This should still return true because it is not wound up yet.
            tp.WindUp();
            tp.StartEngine();
            bool startedEngineAfterWind = tp.Engine.IsStarted; // This should return true because the plane has been wound.
            tp.StopEngine();
            bool stoppedEngine = tp.Engine.IsStarted; // This should return false because the engine has been stopped.
            tp.UnWind();
            tp.StartEngine();
            bool startedEngineAfterUnwind = tp.Engine.IsStarted; // This should return false because the plane has been unwound.
            //Assert
            Assert.AreEqual(defaultEngine, false);
            Assert.AreEqual(startedEngineBeforeWind, false);
            Assert.AreEqual(startedEngineAfterWind, true);
            Assert.AreEqual(stoppedEngine, false);
            Assert.AreEqual(startedEngineAfterUnwind, false);
        }

        [TestMethod]
        public void ToyPlaneTakeOff() {
            //Arrange 
            ToyPlane tp = this.ToyPlane;
            //act
            string firstTakeoff = tp.TakeOff();
            bool windUpStatusBeforeStart = tp.IsWoundUp;
            bool engineBeforeStart = tp.Engine.IsStarted;
            tp.WindUp();
            tp.StartEngine();
            string secondTakeOff = tp.TakeOff();
            //Assert
            Assert.AreEqual(firstTakeoff, tp.ToString() + " can't fly, its engine is not started.");
            Assert.AreEqual(secondTakeOff, tp.ToString() + " is flying.");
            Assert.AreEqual(windUpStatusBeforeStart, false);
            Assert.AreEqual(engineBeforeStart, false);
            Assert.AreEqual(tp.Engine.IsStarted, true);
        }

        [TestMethod]
        public void ToyPlaneFlyUp() {
            //Arrange
            ToyPlane tp = this.ToyPlane;
            //act
            tp.WindUp();
            tp.StartEngine();
            string firstTakeoff = tp.TakeOff();
            int defaultHeight = tp.CurrentAltitude;
            tp.FlyUp(); // This should fail, because the AerialVehicle's FlyUp() goes up 1000 ft, while the ToyPlane has a maximum altitude of 50 ft.
            int firstAlt = tp.CurrentAltitude;
            tp.FlyUp(50);
            int secondAlt = tp.CurrentAltitude;
            tp.FlyUp(1); // This should fail and return the same value as the previous.
            int thirdAlt = tp.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(firstAlt, 0);
            Assert.AreEqual(secondAlt, 50);
            Assert.AreEqual(thirdAlt, secondAlt);

        }

        [TestMethod]
        public void ToyPlaneFlyDown() {
            //Arrange 
            ToyPlane tp = this.ToyPlane;
            //act
            tp.WindUp();
            tp.StartEngine();
            string firstTakeoff = tp.TakeOff();
            int defaultHeight = tp.CurrentAltitude;
            tp.FlyDown();
            //test is flying again
            int FlyDown = tp.CurrentAltitude;
            tp.TakeOff();
            tp.FlyDown(1);
            //test is flying again
            tp.TakeOff();
            int FlyDownOneAlreadyZero = tp.CurrentAltitude;
            tp.FlyUp(2);
            tp.FlyDown(1);
            int FlyDownOneAtTwo = tp.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(FlyDown, 0);
            Assert.AreEqual(FlyDownOneAlreadyZero, 0);
            Assert.AreEqual(FlyDownOneAtTwo, 1);
        }
    }
}
