using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ReproApp.ViewModels;
using Uno.Toolkit.UI;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ReproApp;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        VM.ActivePage = new HomePage(VM);
    }

    public HomeViewModel VM { get; set; } = new();

    private async void SelectFileButton_Click(object sender, RoutedEventArgs e)
    {
        var picker = new FileOpenPicker()
        {
            FileTypeFilter =
            {
                ".jpg", ".png",
            },
        };

        // Get the current window's HWND by passing a Window object
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

        StorageFile file = await picker.PickSingleFileAsync();
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

#if __ANDROID__ || __IOS__
    private async void CaptureFromCameraButton_Click(object sender, RoutedEventArgs e)
    {
        var captureUI = new CameraCaptureUI();

        var file = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
        await AddStorageFileAsync(file);
    }
#endif
}
