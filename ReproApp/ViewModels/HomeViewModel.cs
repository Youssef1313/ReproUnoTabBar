using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Controls;

namespace ReproApp.ViewModels;

public sealed class HomeViewModel : BindableBase
{
    public ObservableCollection<ByteArrayWrapper> ImagesToScan { get; } = new();

    private Page? _activePage;
    private int _selectedIndex;

    public Page? ActivePage
    {
        get => _activePage;
        set => SetProperty(ref _activePage, value);
    }

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            SetProperty(ref _selectedIndex, value);
        }
    }
}
