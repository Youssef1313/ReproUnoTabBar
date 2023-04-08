using System.IO;
using Microsoft.UI.Xaml.Media.Imaging;

namespace ReproApp;

public static class Helpers
{
    public static BitmapImage ConvertByteArrayToBitmapImage(ByteArrayWrapper bytes)
    {
        using (var ms = new MemoryStream(bytes.Bytes))
        {
            var image = new BitmapImage();
            image.SetSource(ms.AsRandomAccessStream());
            return image;
        }
    }
}
