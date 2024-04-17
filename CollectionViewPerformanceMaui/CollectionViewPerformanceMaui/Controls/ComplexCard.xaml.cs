using CollectionViewPerformanceMaui.Models;
using CommunityToolkit.Mvvm.Input;

namespace CollectionViewPerformanceMaui.Controls;

public partial class ComplexCard : Grid
{
	public ComplexCard()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(Data), typeof(ComplexCard));

    public Data Source
    {
        get => (Data)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    [RelayCommand]
    private async Task OpenLink()
    {
        if (Application.Current?.MainPage is null)
        {
            return;
        }

        await Application.Current.MainPage.DisplayAlert(
            "Ahoy",
            "The link was tapped",
            "Close");
    }

    Queue<SocialButton> cachedSocialButtons = new ();
    Queue<ReviewCard> cachedReviewCards = new ();

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (this.BindingContext is Data data)
        {
            UpdateContainer(
                data.SocialMedia,
                socialButtonsContainer,
                cachedSocialButtons,
                () => new SocialButton { TapCommand = OpenLinkCommand},
                (socialButton, text) => socialButton.SocialText = text);

            UpdateContainer(
                data.Reviews,
                reviewCardsContainer,
                cachedReviewCards,
                () => new ReviewCard(),
                (reviewCard, text) => reviewCard.ReviewText = text);
        }

    }


    void UpdateContainer<TData, TView>(List<TData> data, IStackLayout layout, Queue<TView> cachedViews, Func<TView> initialize, Action<TView, TData> recycle)
            where TView : IView
    {
        // Add more buttons if we don't have enough from the cached cell
        while (data.Count > layout.Count)
        {
            if (!cachedViews.TryDequeue(out var view))
            {
                view = initialize();
            }
            
            layout.Add(view);
        }
        
        // We could have too many buttons too, so let's remove and cache them for later
        while (data.Count < layout.Count && layout.Count > 0)
        {
            if (layout[0] is TView view)
            {
                layout.RemoveAt(0);
                cachedViews.Enqueue(view);
            }
        }

        // Now 'bind' (really update) the view
        for (int i = 0; i < data.Count; i++)
        {
            if (layout[i] is TView view)
                recycle(view, data[i]);
        }
    }
}