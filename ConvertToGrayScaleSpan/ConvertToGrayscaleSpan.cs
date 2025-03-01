using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class ConvertToGrayscaleSpan
{
    public static void ConvertToGrayscale(Bitmap image)
    {
        // Lock the bitmap for direct access
        BitmapData bmpData = image.LockBits(
            new Rectangle(0, 0, image.Width, image.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb); // 24-bit RGB format (no alpha)

        int height = image.Height;
        int width = image.Width;
        int stride = bmpData.Stride; // Width including padding

        // Create a managed array to store pixel data
        byte[] pixelArray = new byte[stride * height];

        // Copy unmanaged memory to managed array
        Marshal.Copy(bmpData.Scan0, pixelArray, 0, pixelArray.Length);

        // Work with the array using Span<byte>
        Span<byte> pixelData = pixelArray.AsSpan();

        for (int y = 0; y < height; y++)
        {
            int rowStart = y * stride; // Start index of the row

            for (int x = 0; x < width; x++)
            {
                int index = rowStart + x * 3; // Position of pixel in array

                // Extract RGB values
                byte blue = pixelData[index];
                byte green = pixelData[index + 1];
                byte red = pixelData[index + 2];

                // Convert to grayscale using luminance formula
                byte gray = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);

                // Assign grayscale value to all three channels
                pixelData[index] = gray;
                pixelData[index + 1] = gray;
                pixelData[index + 2] = gray;
            }
        }

        // Copy modified pixel data back to the bitmap
        Marshal.Copy(pixelArray, 0, bmpData.Scan0, pixelArray.Length);

        // Unlock the bitmap
        image.UnlockBits(bmpData);
    }
}
