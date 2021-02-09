using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint_0_Warm_Up;

// Note: Test code modified from test files within the provided UnitTestProjectAV folder.

namespace UnitTestsForSprint0 {
    [TestClass]
    public class EngineTests {
        [TestMethod]
        public void EngineIsStarted() {
            //Arrange
            Engine e = new Engine();
            //Act 
            bool defaultEngineStarted = e.IsStarted;
            e.Start();
            bool startEngineStarted = e.IsStarted;
            e.Stop();
            bool stopEngineStarted = e.IsStarted;
            //Assert
            Assert.AreEqual(defaultEngineStarted, false);
            Assert.AreEqual(startEngineStarted, true);
            Assert.AreEqual(stopEngineStarted, false);
        }
    }
}
