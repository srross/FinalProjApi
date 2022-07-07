namespace FinalProjApi.Models
{
    public class OutfitWeather
    {
		public int OutfitId { get; set; } // Primary Key
		public int OutfitScale { get; set; } // use max OutfitScale number for this variable
		public string OutfitBottom { get; set; }
		public string OutfitTop { get; set; }
		public string OutfitHead { get; set; }
		public string OutfitHands { get; set; }
		public string OutfitImage { get; set; }
		public int UserId { get; set; } // Foreign Key
	}
}
