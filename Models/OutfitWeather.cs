namespace FinalProjApi.Models
{
    public class OutfitWeather
    {
		public int Id { get; set; } // Primary Key
		public double MinTemperature { get; set; }
		public string OutfitBottom { get; set; }
		public string OutfitTop { get; set; }
		public string OutfitHead { get; set; }
		public string OutfitHands { get; set; }
		public string OutfitImage { get; set; }
		public int UserId { get; set; } // Foreign Key
		public double MaxTemperature { get; set; }
	}
}
