namespace FinalProjApi.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class CurrentWeather
    {
        public DateTime LocalObservationDateTime { get; set; }
        public string WeatherText { get; set; }

        public Temperature Temperature { get; set; }

        public int RelativeHumidity { get; set; }

        public Wind Wind { get; set; }

        public int CloudCover { get; set; }

        public ApparentTemperature ApparentTemperature { get; set; }

    }

    public class ApparentTemperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Direction
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }

    public class Imperial
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }


    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }


    public class Speed
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Wind
    {
        public Direction Direction { get; set; }
        public Speed Speed { get; set; }
    }
    
}
