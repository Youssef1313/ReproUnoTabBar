using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using ReproApp.ViewModels;
using Windows.Media.Capture;
using Windows.Storage;

namespace ReproApp;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        VM.ActivePage = new HomePage(VM);
    }

    public HomeViewModel VM { get; set; } = new();


#if __ANDROID__ || __IOS__
    private async void myRect_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
    {
        var captureUI = new CameraCaptureUI();

        var file = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
        await AddStorageFileAsync(file);
    }

    private async Task AddStorageFileAsync(StorageFile? file)
    {
        if (file != null)
        {
            using var stream = await file.OpenStreamForReadAsync();
            var bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);

            VM.ImagesToScan.Add(new ByteArrayWrapper(bytes));
            VM.SelectedIndex = VM.ImagesToScan.Count - 1;
        }
    }
#endif
}
