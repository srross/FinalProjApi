namespace FinalProjApi.Models
{
    public class User
    {
		public int UserId { get; set; } // Primary Key
		public string AuthZeroId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string ZipCode { get; set; } // Default location; can be changed by user anytime.
		public string Key { get; set; } // This is returned by a call to LocationFinder API where zip code is sent. Key is used by Current Weather API.
		public string Activity { get; set; } // Consider making this an enum. To start, only include Run, Walk. User can edit and create more, so enum may not be suitable.
		public int OutfitScaleOffset { get; set; } // negative or positive number to adjust the standard OutfitScale score by.
	}
}
