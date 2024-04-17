using CollectionViewPerformanceMaui.Enums;
using CollectionViewPerformanceMaui.Helpers;
using CollectionViewPerformanceMaui.Resources.Fonts;

namespace CollectionViewPerformanceMaui.Models
{
	public sealed class Data
	{
		public Template Template { get; set; }

		public VlvAdapter Adapter { get; set; } = new VlvAdapter(this);
		
        public string RestaurantName { get; set; } = string.Empty;

        public string RestaurantDescription { get; set; } = string.Empty;

        public string RestaurantAddress { get; set; } = string.Empty;

        public string Rating { get; set; } = string.Empty;

		public string Review { get; set; } = string.Empty;

		public List<string> Reviews { get; set; } = new();

        public List<string> SocialMedia { get; set; } = new();

        
        public Data()
		{
			var random = new Random();

			this.Template = Template.CardWithTheLot;
			this.RestaurantName = RandomContentHelper.GenerateRandomRestaurantName();
			this.RestaurantDescription = RandomContentHelper.GenerateRandomSentence(5);
			this.RestaurantAddress = RandomContentHelper.GenerateRandomAddress();

			this.Rating = RandomContentHelper.GenerateRandomRating();

            this.Review = RandomContentHelper.GenerateRandomSentence(random.Next(6, 12));

            this.Reviews = new List<string>();
            var reviewCount = random.Next(1, 4);
            while (Reviews.Count < reviewCount)
            {
	            this.Reviews.Add(RandomContentHelper.GenerateRandomSentence(random.Next(6, 12)));
            };
            
            var socialTypes = new []
			{
				FontAwesome.Instagram,
				FontAwesome.Facebook,
				FontAwesome.Tiktok,
			};
			this.SocialMedia = new List<string>();
			var socialCount = random.Next(1, 4);
			for (int i = 0; i < socialCount; i++)
			{
				SocialMedia.Add(socialTypes[i]);
			}

			// random.Next(0, 2) == 1; // 50/50 chance
		}
	}
}
