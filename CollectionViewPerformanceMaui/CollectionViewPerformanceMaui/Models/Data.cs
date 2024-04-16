using CollectionViewPerformanceMaui.Enums;
using CollectionViewPerformanceMaui.Helpers;
using CollectionViewPerformanceMaui.Resources.Fonts;

namespace CollectionViewPerformanceMaui.Models
{
	public sealed class Data
	{
		public Template Template { get; set; }

        public string RestaurantName { get; set; } = string.Empty;

        public string RestaurantDescription { get; set; } = string.Empty;

        public string RestaurantAddress { get; set; } = string.Empty;

        public string Rating { get; set; } = string.Empty;

		public string Review { get; set; } = string.Empty;

		public List<string> Reviews { get; set; } = new();

		public bool HasReview1 => Reviews.Count >= 1;
		public bool HasReview2 => Reviews.Count >= 2;
		public bool HasReview3 => Reviews.Count >= 3;

		public string? Review1 => HasReview1 ? Reviews[0] : null;
		public string? Review2 => HasReview2 ? Reviews[1] : null;
		public string? Review3 => HasReview3 ? Reviews[2] : null;
		

        public List<string> SocialMedia { get; set; } = new();

        public bool HasSocial1 => SocialMedia.Count >= 1;
        public bool HasSocial2 => SocialMedia.Count >= 2;
        public bool HasSocial3 => SocialMedia.Count >= 3;
        
        public string? Social1 => HasReview1 ? SocialMedia[0] : null;
        public string? Social2 => HasReview2 ? SocialMedia[1] : null;
        public string? Social3 => HasReview3 ? SocialMedia[2] : null;
        
        public Data()
		{
			var random = new Random();

			this.Template = Template.CardWithTheLot;
			this.RestaurantName = RandomContentHelper.GenerateRandomRestaurantName();
			this.RestaurantDescription = RandomContentHelper.GenerateRandomSentence(5);
			this.RestaurantAddress = RandomContentHelper.GenerateRandomAddress();

			this.Rating = RandomContentHelper.GenerateRandomRating();

            this.Review = RandomContentHelper.GenerateRandomSentence(random.Next(6, 12));
            this.Reviews = new List<string>()
            {
                RandomContentHelper.GenerateRandomSentence(random.Next(6, 12)),
                RandomContentHelper.GenerateRandomSentence(random.Next(6, 12)),
                RandomContentHelper.GenerateRandomSentence(random.Next(6, 12))
            };

			this.SocialMedia = new List<string>()
			{
				FontAwesome.Instagram,
				FontAwesome.Facebook,
				FontAwesome.Tiktok,
			};

			// random.Next(0, 2) == 1; // 50/50 chance
		}
	}
}
