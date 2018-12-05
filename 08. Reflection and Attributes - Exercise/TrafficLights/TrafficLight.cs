namespace TrafficLights
{
    using System;

    public class TrafficLight
    {
        private Light currentColor;

        public TrafficLight(string color)
        {
            this.currentColor = (Light)Enum.Parse(typeof(Light), color);
        }

        public void Update()
        {
            int lastColor = (int)this.currentColor;
            this.currentColor = (Light)(++lastColor % Enum.GetNames(typeof(Light)).Length);
        }
    }
}
