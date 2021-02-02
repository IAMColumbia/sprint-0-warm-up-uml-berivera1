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