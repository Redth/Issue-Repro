using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewPerformanceMaui.Controls;

public partial class SocialButton : Border
{
    public SocialButton()
    {
        InitializeComponent();
    }

    public string SocialText
    {
        get => labelText.Text;
        set => labelText.Text = value;
    }

    public ICommand TapCommand
    {
        get => this.tapGesture.Command;
        set => this.tapGesture.Command = value;
    }
}