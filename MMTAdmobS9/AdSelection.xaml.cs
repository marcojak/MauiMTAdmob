using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTAdmobSample9;

public partial class AdSelection : ContentPage
{
    public AdSelection()
    {
        InitializeComponent();
    }

    private void AdMobButton(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void AdManagerButton(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new AdMPage());
    }
}