using Microsoft.UI.Xaml.Controls;
using ReproApp.ViewModels;

namespace ReproApp;

public sealed partial class HomePage : Page
{
    public HomeViewModel VM { get; }

    public HomePage(HomeViewModel vm)
    {
        VM = vm;
        this.InitializeComponent();
    }
}
