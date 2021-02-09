namespace Sprint_0_Warm_Up
{
    public class Engine
    {
        public bool IsStarted { get; set; }

        public Engine()
        {
            IsStarted = false;
        }

        public string About()
        {
            // NOTE TO SELF: What does the Engine's About() method return?
            // Maybe this could return the status string, but would that make AerialVehicle's GetEngineStartedString() method obsolete?
            return "TO DO";
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop() {
            IsStarted = false;
        }
    }
}