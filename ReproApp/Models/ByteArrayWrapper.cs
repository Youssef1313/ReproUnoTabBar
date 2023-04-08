using ReproApp.ViewModels;

namespace ReproApp;

public sealed class ByteArrayWrapper : BindableBase
{
    public ByteArrayWrapper(byte[] bytes)
    {
        Bytes = bytes;
    }

    public byte[] Bytes { get; }
}
