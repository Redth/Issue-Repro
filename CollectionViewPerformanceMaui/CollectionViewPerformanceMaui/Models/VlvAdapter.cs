using CollectionViewPerformanceMaui.Controls;
using CollectionViewPerformanceMaui.Enums;
using CollectionViewPerformanceMaui.ViewModels;
using Microsoft.Maui.Adapters;

namespace CollectionViewPerformanceMaui.Models;

public class VlvAdapter : ObservableCollectionAdapter<Data>
{
    public VlvAdapter(DataViewModel data) : base(data.Data)
    {
        Data = data;
    }

    private DataViewModel Data { get; }
}

public class VlvTemplateSelector : VirtualListViewItemTemplateSelector
{
    public override DataTemplate SelectTemplate(object item, int sectionIndex, int itemIndex)
    {
        return new DataTemplate(typeof(ComplexCard));
    }
}