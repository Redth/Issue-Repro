using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewPerformanceMaui.Controls;

public partial class ReviewCard : Border
{
    public ReviewCard()
    {
        InitializeComponent();
    }

    public string ReviewText
    {
        get => labelReview.Text;
        set => labelReview.Text = value;
    }
}